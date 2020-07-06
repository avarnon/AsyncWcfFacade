using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Unity;

namespace AsyncWcfFacade.Unity
{
    public class UnityServiceHostFactory : ServiceHostFactory
    {
        public UnityServiceHostFactory()
            : this(UnityConfig.Container)
        {
        }

        public UnityServiceHostFactory(IUnityContainer container)
        {
            this.Container = container ?? throw new ArgumentNullException(nameof(container));
        }

        private IUnityContainer Container { get; }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses) => new UnityServiceHost(serviceType, this.Container, baseAddresses);
    }
}