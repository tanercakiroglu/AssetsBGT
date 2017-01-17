using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Assets.Service.Interceptor
{
    public class NonSecuredRequestMessageInterceptor : IDispatchMessageInspector
    {
        const string MessageLogFolder = @"C:\";
        static int messageLogFileIndex = 0;
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            Task.Run(() => LogRequest(buffer));
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {

        }

        private static void LogRequest(MessageBuffer buffer)
        {
            Message request = null;
            if (buffer != null)
                request = buffer.CreateMessage();
            if (request != null)
            {
                string messageFileName = string.Format("{0}Log{1:000}_NonSecuredIncoming.txt", MessageLogFolder, Interlocked.Increment(ref messageLogFileIndex));
                Uri requestUri = request.Headers.To;
                using (StreamWriter sw = File.CreateText(messageFileName))
                {
                    HttpRequestMessageProperty httpReq = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

                    sw.WriteLine("{0} {1} {2}", httpReq.Method, requestUri,DateTime.Now);
                    foreach (var header in httpReq.Headers.AllKeys)
                    {
                        sw.WriteLine("{0}: {1}", header, httpReq.Headers[header]);
                    }

                    if (!request.IsEmpty)
                    {
                        sw.WriteLine();
                        sw.WriteLine(MessageToString(ref request));
                    }
                }
            }
        }

        private static string MessageToString(ref Message message)
        {
            WebContentFormat messageFormat = GetMessageContentFormat(message);
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = null;
            switch (messageFormat)
            {
                case WebContentFormat.Default:
                case WebContentFormat.Xml:
                    writer = XmlDictionaryWriter.CreateTextWriter(ms);
                    break;
                case WebContentFormat.Json:
                    writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                    break;
                case WebContentFormat.Raw:
                    // special case for raw, easier implemented separately 
                    return ReadRawBody(ref message);
            }

            message.WriteMessage(writer);
            writer.Flush();
            string messageBody = Encoding.UTF8.GetString(ms.ToArray());

            // Here would be a good place to change the message body, if so desired. 

            // now that the message was read, it needs to be recreated. 
            ms.Position = 0;

            // if the message body was modified, needs to reencode it, as show below 
            // ms = new MemoryStream(Encoding.UTF8.GetBytes(messageBody));

            XmlDictionaryReader reader;
            if (messageFormat == WebContentFormat.Json)
            {
                reader = JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max);
            }
            else
            {
                reader = XmlDictionaryReader.CreateTextReader(ms, XmlDictionaryReaderQuotas.Max);
            }

            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }

        private static WebContentFormat GetMessageContentFormat(Message message)
        {
            WebContentFormat format = WebContentFormat.Default;
            if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
            {
                WebBodyFormatMessageProperty bodyFormat;
                bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
                format = bodyFormat.Format;
            }

            return format;
        }

        private static string ReadRawBody(ref Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            string messageBody = Encoding.UTF8.GetString(bodyBytes);

            // Now to recreate the message 
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
            writer.WriteStartElement("Binary");
            writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
            writer.WriteEndElement();
            writer.Flush();
            ms.Position = 0;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }
    }
}