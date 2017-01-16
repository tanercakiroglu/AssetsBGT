using Assets.Service.Interceptor;
using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Assets.Service.Behaviour
{
    public class SecuredServiceBehavior : Attribute, IServiceBehavior
    {
        public SecuredServiceBehavior()
        {
        }

        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;

                if (cd != null)
                {
                    foreach (EndpointDispatcher ed in cd.Endpoints)
                    {
                         ed.DispatchRuntime.MessageInspectors.Add(new SecuredRequestMessageInterceptor());
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {

        }

        #endregion IServiceBehavior Members
    }
}