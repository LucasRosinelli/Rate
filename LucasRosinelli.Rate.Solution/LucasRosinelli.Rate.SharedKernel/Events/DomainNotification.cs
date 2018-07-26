using LucasRosinelli.Rate.SharedKernel.Contracts;
using System;

namespace LucasRosinelli.Rate.SharedKernel.Events
{
    /// <summary>
    /// Notifications of the domain.
    /// </summary>
    public class DomainNotification : IDomainEvent
    {
        #region Properties

        /// <summary>
        /// Notification key.
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// Notification value.
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// Notification identifier.
        /// </summary>
        public int Identifier { get; private set; }
        /// <summary>
        /// Additional information for notification.
        /// </summary>
        public string AdditionalInfo { get; private set; }
        /// <summary>
        /// Exception linked to this notification, if exists.
        /// </summary>
        public Exception Exception { get; private set; }
        /// <summary>
        /// Date and time when notification occurred.
        /// </summary>
        public DateTime DateOccurred { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the notification.
        /// </summary>
        /// <param name="key">Notification key.</param>
        /// <param name="value">Notification value.</param>
        /// <param name="identifier">Notification identifier.</param>
        /// <param name="additionalInfo">Additional information for notification.</param>
        public DomainNotification(string key, string value, int identifier = RateConstants.MessageNotIdentified, string additionalInfo = null)
            : this(key, value, identifier, additionalInfo, null)
        {
        }

        /// <summary>
        /// Initializes the notification.
        /// </summary>
        /// <param name="key">Notification key.</param>
        /// <param name="value">Notification value.</param>
        /// <param name="identifier">Notification identifier.</param>
        /// <param name="additionalInfo">Additional information for notification.</param>
        /// <param name="exception">Exception linked to this notification, if exists.</param>
        public DomainNotification(string key, string value, int identifier, string additionalInfo, Exception exception)
        {
            this.Key = key;
            this.Value = value;
            this.Identifier = identifier;
            this.AdditionalInfo = additionalInfo;
            this.Exception = exception;
            this.DateOccurred = DateTime.Now;
        }

        #endregion
    }
}