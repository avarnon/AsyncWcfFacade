using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Unity;

namespace AsyncWcfFacade.Unity
{
    /// <summary>
    /// The <see cref="UnityInstanceProvider"/>
    ///   class is used by WCF to create a new instance of a service contract.
    /// </summary>
    internal class UnityInstanceProvider : IInstanceProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityInstanceProvider"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="serviceType">
        /// Type of the service.
        /// </param>
        /// <param name="resolveName">
        /// Name of the resolve.
        /// </param>
        public UnityInstanceProvider(IUnityContainer container, Type serviceType, String resolveName)
        {
            this.Container = container ?? throw new ArgumentNullException(nameof(container));
            this.ServiceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType));
            this.ResolveName = resolveName;
        }

        /// <summary>
        ///   Gets or sets the name of the resolve.
        /// </summary>
        /// <value>
        ///   The name of the resolve.
        /// </value>
        protected string ResolveName { get; }

        /// <summary>
        ///   Gets or sets the type of the service.
        /// </summary>
        /// <value>
        ///   The type of the service.
        /// </value>
        protected Type ServiceType { get; }

        /// <summary>
        ///   Gets or sets the container.
        /// </summary>
        /// <value>
        ///   The container.
        /// </value>
        private IUnityContainer Container { get; }

        /// <summary>
        /// Returns a service object given the specified <see cref="T:System.ServiceModel.InstanceContext"/> object.
        /// </summary>
        /// <returns>
        /// A user-defined service object.
        /// </returns>
        /// <param name="instanceContext">
        /// The current <see cref="T:System.ServiceModel.InstanceContext"/> object.
        /// </param>
        public object GetInstance(InstanceContext instanceContext) => GetInstance(instanceContext, null);

        /// <summary>
        /// Returns a service object given the specified <see cref="T:System.ServiceModel.InstanceContext"/> object.
        /// </summary>
        /// <returns>
        /// The service object.
        /// </returns>
        /// <param name="instanceContext">
        /// The current <see cref="T:System.ServiceModel.InstanceContext"/> object.
        /// </param>
        /// <param name="message">
        /// The message that triggered the creation of a service object.
        /// </param>
        public object GetInstance(InstanceContext instanceContext, Message message) => this.Container.Resolve(this.ServiceType, this.ResolveName);

        /// <summary>
        /// Called when an <see cref="T:System.ServiceModel.InstanceContext"/> object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">
        /// The service's instance context.
        /// </param>
        /// <param name="instance">
        /// The service object to be recycled.
        /// </param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance) { }
    }
}