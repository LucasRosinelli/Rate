using LucasRosinelli.Rate.SharedKernel.Contracts;
using System;

namespace LucasRosinelli.Rate.Api
{
    /// <summary>
    /// Domain events container.
    /// </summary>
    public class DomainEventsContainer : IContainer
    {
        #region Field

        /// <summary>
        /// Service provider.
        /// </summary>
        private IServiceProvider _serviceProvider;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the container.
        /// </summary>
        /// <param name="serviceProvider">Service provider.</param>
        public DomainEventsContainer(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the service of specific type as a generic object.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>Service as an object.</returns>
        public object GetService(Type serviceType)
        {
            return this._serviceProvider.GetService(serviceType);
        }

        /// <summary>
        /// Gets the service of specific type.
        /// </summary>
        /// <typeparam name="T">Type of the service.</typeparam>
        /// <returns>Service.</returns>
        public T GetService<T>()
        {
            return (T)this._serviceProvider.GetService(typeof(T));
        }

        #endregion
    }
}