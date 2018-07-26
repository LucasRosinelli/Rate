using LucasRosinelli.Rate.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LucasRosinelli.Rate.SharedKernel.Validation
{
    /// <summary>
    /// Assertion methods.
    /// </summary>
    public static class AssertionConcern
    {
        #region Methods

        /// <summary>
        /// Checks if all notifications are satisfied.
        /// </summary>
        /// <param name="validations">Notifications to check.</param>
        /// <returns>true if satisfied; otherwise, false.</returns>
        public static bool IsSatisfiedBy(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            var domainNotifications = notificationsNotNull as IList<DomainNotification> ?? notificationsNotNull.ToList();

            NotifyAll(domainNotifications);

            return !domainNotifications.Any();
        }

        /// <summary>
        /// Raises all notifications.
        /// </summary>
        /// <param name="notifications">Notifications to raise.</param>
        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(DomainEvent.Raise);
        }

        /// <summary>
        /// Checks if the length of <see cref="string" /> has minimum and maximum lengths.
        /// </summary>
        /// <param name="value">Value to check the length.</param>
        /// <param name="minimum">Minimum length.</param>
        /// <param name="maximum">Maximum length.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertLength(string value, int minimum, int maximum, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            var length = string.IsNullOrWhiteSpace(value) ? 0 : value.Trim().Length;

            if (length < minimum || length > maximum)
            {
                return new DomainNotification(RateConstants.AssertArgumentLength, message, identifier);
            }

            return null;
        }

        /// <summary>
        /// Checks if the <see cref="string" /> matches to <see cref="Regex" /> pattern.
        /// </summary>
        /// <param name="pattern">Regex pattern.</param>
        /// <param name="value">Value to check.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertMatches(string pattern, string value, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            var regex = new Regex(pattern);

            return !regex.IsMatch(value) ? new DomainNotification(RateConstants.AssertArgumentMatches, message, identifier) : null;
        }

        /// <summary>
        /// Checks if the value is not empty (null, empty, or only white-spaces).
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertNotEmpty(string value, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return string.IsNullOrWhiteSpace(value) ? new DomainNotification(RateConstants.AssertArgumentNotEmpty, message, identifier) : null;
        }

        /// <summary>
        /// Checks if the value is greater than zero.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertValueIsGreaterThanZero(int value, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return value <= 0 ? new DomainNotification(RateConstants.AssertArgumentNotEmpty, message, identifier) : null;
        }

        /// <summary>
        /// Checks if the value is greater than zero.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertValueIsGreaterThanZero(decimal value, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return value <= 0 ? new DomainNotification(RateConstants.AssertArgumentNotEmpty, message, identifier) : null;
        }

        /// <summary>
        /// Checks if the <see cref="object"/> is not null.
        /// </summary>
        /// <param name="object1"><see cref="Object"/> to check.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertNotNull(object object1, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return object1 == null ? new DomainNotification(RateConstants.AssertArgumentNotNull, message, identifier) : null;
        }

        /// <summary>
        /// Checks if the value is true.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertTrue(bool value, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return !value ? new DomainNotification(RateConstants.AssertArgumentTrue, message, identifier) : null;
        }

        /// <summary>
        /// Checks if the value is false.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertFalse(bool value, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return value ? new DomainNotification(RateConstants.AssertArgumentTrue, message, identifier) : null;
        }

        /// <summary>
        /// Checks if the value and match are equals.
        /// </summary>
        /// <param name="value">Value to checks if it is equal.</param>
        /// <param name="match">Value used to compare to.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertAreEquals(string value, string match, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return value != match ? new DomainNotification(RateConstants.AssertArgumentAreEquals, message, identifier) : null;
        }

        /// <summary>
        /// Checks if value1 is greater than value2.
        /// </summary>
        /// <param name="value1">Value to checks if it is greater than.</param>
        /// <param name="value2">Value used to compare to.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification if necessary; otherwise, null.</returns>
        public static DomainNotification AssertIsGreaterThan(int value1, int value2, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return !(value1 > value2) ? new DomainNotification(RateConstants.AssertArgumentIsGreaterThan, message, identifier) : null;
        }

        /// <summary>
        /// Checks if value1 is greater than value2.
        /// </summary>
        /// <param name="value1">Value to checks if it is greater than.</param>
        /// <param name="value2">Value used to compare to.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification if necessary; otherwise, null.</returns>
        public static DomainNotification AssertIsGreaterThan(decimal value1, decimal value2, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return !(value1 > value2) ? new DomainNotification(RateConstants.AssertArgumentIsGreaterThan, message, identifier) : null;
        }

        /// <summary>
        /// Checks if value1 is greater than value2.
        /// </summary>
        /// <param name="value1">Value to checks if it is greater than.</param>
        /// <param name="value2">Value used to compare to.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification if necessary; otherwise, null.</returns>
        public static DomainNotification AssertIsGreaterThan(DateTime value1, DateTime value2, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return !(value1 > value2) ? new DomainNotification(RateConstants.AssertArgumentIsGreaterThan, message, identifier) : null;
        }

        /// <summary>
        /// Checks if value1 is greater or equal than value2.
        /// </summary>
        /// <param name="value1">Value to checks if it is greater or equal than.</param>
        /// <param name="value2">Value used to compare to.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertIsGreaterOrEqualThan(int value1, int value2, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return !(value1 >= value2) ? new DomainNotification(RateConstants.AssertArgumentIsGreaterOrEqualThan, message, identifier) : null;
        }

        /// <summary>
        /// Checks if value1 is greater or equal than value2.
        /// </summary>
        /// <param name="value1">Value to checks if it is greater or equal than.</param>
        /// <param name="value2">Value used to compare to.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertIsGreaterOrEqualThan(decimal value1, decimal value2, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return !(value1 >= value2) ? new DomainNotification(RateConstants.AssertArgumentIsGreaterOrEqualThan, message, identifier) : null;
        }

        /// <summary>
        /// Checks if value1 is greater or equal than value2.
        /// </summary>
        /// <param name="value1">Value to checks if it is greater or equal than.</param>
        /// <param name="value2">Value used to compare to.</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertIsGreaterOrEqualThan(DateTime value1, DateTime value2, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            return !(value1 >= value2) ? new DomainNotification(RateConstants.AssertArgumentIsGreaterOrEqualThan, message, identifier) : null;
        }

        /// <summary>
        /// Checks if value is between minimum and maximum, similar to greater or equal than minimum and less or equal to maximum.
        /// </summary>
        /// <param name="value">Value to checks if it is in the interval.</param>
        /// <param name="minimum">Minimum value (included).</param>
        /// <param name="maximum">Maximum value (included).</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertBetween(int value, int minimum, int maximum, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            if (value < minimum || value > maximum)
            {
                return new DomainNotification(RateConstants.AssertArgumentBetween, message, identifier);
            }

            return null;
        }

        /// <summary>
        /// Checks if value is between minimum and maximum, similar to greater or equal than minimum and less or equal to maximum.
        /// </summary>
        /// <param name="value">Value to checks if it is in the interval.</param>
        /// <param name="minimum">Minimum value (included).</param>
        /// <param name="maximum">Maximum value (included).</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertBetween(decimal value, decimal minimum, decimal maximum, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            if (value < minimum || value > maximum)
            {
                return new DomainNotification(RateConstants.AssertArgumentBetween, message, identifier);
            }

            return null;
        }

        /// <summary>
        /// Checks if value is between minimum and maximum, similar to greater or equal than minimum and less or equal to maximum.
        /// </summary>
        /// <param name="value">Value to checks if it is in the interval.</param>
        /// <param name="minimum">Minimum value (included).</param>
        /// <param name="maximum">Maximum value (included).</param>
        /// <param name="message">Error message used to create notification, if necessary.</param>
        /// <param name="identifier">Identifier used to create notification, if necessary.</param>
        /// <returns>Notification, if necessary; otherwise, null.</returns>
        public static DomainNotification AssertBetween(DateTime value, DateTime minimum, DateTime maximum, string message, int identifier = RateConstants.MessageNotIdentified)
        {
            if (value < minimum || value > maximum)
            {
                return new DomainNotification(RateConstants.AssertArgumentBetween, message, identifier);
            }

            return null;
        }

        #endregion
    }
}