using Assets.BusinessLogic.Implementation;
using Assets.BusinessLogic.Interface;
using Assets.DataAccessLayer.Implementation;
using Assets.DataAccessLayer.Interface;
using Ninject;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Assets.IocContainer
{
    public class NInjectServiceHostFactory : ServiceHostFactory
    {
        private readonly IKernel kernel;

        public NInjectServiceHostFactory()
        {
            kernel = new StandardKernel();
            kernel.Bind<ICommonManager>().To<CommonManager>();
            kernel.Bind<ICountryRepository>().To<CountryRepository>();
            kernel.Bind<IUserManager>().To<UserManager>();
            kernel.Bind<IProvinceRepository>().To<ProvinceRepository>();
            kernel.Bind<IDistrictRepository>().To<DistrictRepository>();
            //add the rest of the mappings here
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new NInjectServiceHost(kernel, serviceType, baseAddresses);
        }
    }

    public class NInjectServiceHost : ServiceHost
    {
        public NInjectServiceHost(IKernel kernel, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (kernel == null) throw new ArgumentNullException("kernel");
            foreach (var cd in ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new NInjectInstanceProvider(kernel));
            }
        }
    }
}