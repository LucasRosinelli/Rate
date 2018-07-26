using LucasRosinelli.Rate.Infrastructure.Persistence;
using LucasRosinelli.Rate.SharedKernel.Contracts;
using LucasRosinelli.Rate.SharedKernel.Events;

namespace LucasRosinelli.Rate.ApplicationService
{
    /// <summary>
    /// Base class for business intelligence.
    /// </summary>
    public abstract class ApplicationServiceBase
    {
        #region Fields

        /// <summary>
        /// Unit of work for transactions.
        /// </summary>
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// Notifications.
        /// </summary>
        private IHandler<DomainNotification> _notifications;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes business intelligence.
        /// </summary>
        /// <param name="unitOfWork">Unit of work for transactions.</param>
        public ApplicationServiceBase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = (IHandler<DomainNotification>)DomainEvent.Container.GetService(typeof(IHandler<DomainNotification>));
        }

        #endregion

        #region Method

        /// <summary>
        /// Confirms transactions.
        /// </summary>
        /// <returns>true is succeeded; otherwise, false.</returns>
        public bool Commit()
        {
            if (this._notifications.HasNotifications())
            {
                return false;
            }

            this._unitOfWork.Commit();
            return true;
        }

        #endregion
    }
}