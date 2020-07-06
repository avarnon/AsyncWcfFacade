using System;
using System.ServiceModel;
using Unity;

namespace AsyncWcfFacade.Unity
{
    /// <summary>
    /// The <see cref="UnityServiceHost"/>
    ///   class provides a service host that creates WCF service instances using Unity.
    /// </summary>
    public class UnityServiceHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">
        /// Type of the service.
        /// </param>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="baseAddresses">
        /// The base addresses.
        /// </param>
        public UnityServiceHost(Type serviceType, IUnityContainer container, params Uri[] baseAddresses)
            : base(serviceType ?? throw new ArgumentNullException(nameof(serviceType)), baseAddresses)
        {
            this.Container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <summary>
        ///   Gets the container.
        /// </summary>
        /// <value>
        ///   The container.
        /// </value>
        protected IUnityContainer Container { get; }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            if (this.Description.Behaviors.Find<UnityServiceBehavior>() == null)
            {
                this.Description.Behaviors.Add(new UnityServiceBehavior(this.Container));
            }

            base.OnOpening();
        }
    }
}