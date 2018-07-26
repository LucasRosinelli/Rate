using LucasRosinelli.Rate.SharedKernel.Contracts;
using LucasRosinelli.Rate.SharedKernel.Events;
using System.Collections.Generic;

namespace LucasRosinelli.Rate.Api
{
    /// <summary>
    /// Handle notifications.
    /// </summary>
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        #region Field

        /// <summary>
        /// Notifications.
        /// </summary>
        private List<DomainNotification> _notifications;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes notifications handler.
        /// </summary>
        public DomainNotificationHandler()
        {
            this._notifications = new List<DomainNotification>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the domain event.
        /// </summary>
        /// <param name="args">Domain event to handle.</param>
        public void Handle(DomainNotification args)
        {
            this._notifications.Add(args);
        }

        /// <summary>
        /// Notifies the all events.
        /// </summary>
        /// <returns>Events to notify.</returns>
        public IEnumerable<DomainNotification> Notify()
        {
            return this._notifications;
        }

        /// <summary>
        /// Verifies if notifications exists or not.
        /// </summary>
        /// <returns>true if notification exists; otherwise, false.</returns>
        public bool HasNotifications()
        {
            return this._notifications.Count > 0;
        }

        /// <summary>
        /// Disposes object.
        /// </summary>
        public void Dispose()
        {
            this._notifications = new List<DomainNotification>();
        }

        #endregion
    }
}