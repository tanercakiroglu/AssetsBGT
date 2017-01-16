using Jose;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;

namespace Assets.Service.Interceptor
{
    public class RequestMessageInterceptor : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {

            var headers = request.Properties.Values;
            string auth = null;
            foreach (var item in headers)
            {
                if (item is HttpRequestMessageProperty)
                {
                    var it = (HttpRequestMessageProperty)item;
                    auth = it.Headers["Authorization"];
                }
            }

           ValidateToken(auth);

            return auth;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var headers = reply.Properties.Values;
            foreach (var item in headers)
            {
                if (item is HttpResponseMessageProperty)
                {
                    var it = (HttpResponseMessageProperty)item;
                    it.Headers.Add("Authorization", correlationState.ToString());
                }
            }
        }

        private static void ValidateToken(string auth)
        {
            Dictionary<string, object> tokenElements;
            try
            {
                byte[] toBytes = Encoding.ASCII.GetBytes("YOUR_CLIENT_SECRETsssssssssssssssssssssssssssssssssssssss");
                tokenElements = JWT.Decode<Dictionary<string, object>>(auth, toBytes, JwsAlgorithm.HS512);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new WebFaultException<string>("Invalid Token", HttpStatusCode.Unauthorized);
            }
            if (tokenElements == null)
                throw new WebFaultException<string>("Invalid Signature", HttpStatusCode.Unauthorized);

            if (tokenElements.ContainsKey("iss"))
            {
                if (tokenElements["iss"].ToString()!= ("www.assets.com.tr"))
                    throw new WebFaultException<string>("Invalid Domain", HttpStatusCode.Unauthorized);
            }
            if (tokenElements.ContainsKey("aud"))
            {
                if (tokenElements["aud"].ToString() != ("YOUR_CLIENT_ID"))
                    throw new WebFaultException<string>("Invalid Client", HttpStatusCode.Unauthorized);
            }
            if (tokenElements.ContainsKey("sub"))
            {
                if (tokenElements["sub"].ToString() != ("anonymous"))
                    throw new WebFaultException<string>("Invalid sub", HttpStatusCode.Unauthorized);
            }
            if (tokenElements.ContainsKey("exp"))
            {
                if (Convert.ToDateTime(tokenElements["exp"]) <DateTime.Now)
                    throw new WebFaultException<string>("Token expired", HttpStatusCode.Unauthorized);
            }
        }
    }
}