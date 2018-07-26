using System;

namespace LucasRosinelli.Rate.SharedKernel.Contracts
{
    /// <summary>
    /// Container used to keep services.
    /// </summary>
    public interface IContainer
    {
        #region Methods

        /// <summary>
        /// Gets the service of specific type.
        /// </summary>
        /// <typeparam name="T">Type of the service.</typeparam>
        /// <returns>Service.</returns>
        T GetService<T>();
        /// <summary>
        /// Gets the service of specific type as a generic object.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>Service as an object.</returns>
        object GetService(Type serviceType);

        #endregion
    }
}