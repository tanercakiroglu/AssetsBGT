using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace AssetsBGT.Service.Interceptor
{
    public class RequestMessageInterceptor : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {

            var headers = request.Properties.Values;
            string auth = null;
            foreach (var item in headers)
            {
                if(item is HttpRequestMessageProperty)
                {
                    var it = (HttpRequestMessageProperty)item;
                    auth = it.Headers["Authorization"];
                }
            }
            if("sfdsfmndksfnk"== auth)
                throw new WebFaultException<string>("Missing api key", HttpStatusCode.Unauthorized);

            return request;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            
        }


    }
}