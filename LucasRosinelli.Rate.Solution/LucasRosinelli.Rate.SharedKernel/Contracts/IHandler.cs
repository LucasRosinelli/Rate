using System;
using System.Collections.Generic;

namespace LucasRosinelli.Rate.SharedKernel.Contracts
{
    /// <summary>
    /// Handler for domain events.
    /// </summary>
    /// <typeparam name="T">Domain event type to handle.</typeparam>
    public interface IHandler<T> : IDisposable
        where T : IDomainEvent
    {
        #region Methods

        /// <summary>
        /// Handles the domain event.
        /// </summary>
        /// <param name="args">Domain event to handle.</param>
        void Handle(T args);
        /// <summary>
        /// Notifies the all events.
        /// </summary>
        /// <returns>Events to notify.</returns>
        IEnumerable<T> Notify();
        /// <summary>
        /// Verifies if notifications exists or not.
        /// </summary>
        /// <returns>true if notification exists; otherwise, false.</returns>
        bool HasNotifications();

        #endregion
    }
}