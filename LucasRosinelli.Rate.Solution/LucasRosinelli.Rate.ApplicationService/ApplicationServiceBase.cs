using LucasRosinelli.Rate.Infrastructure.Persistence;
using LucasRosinelli.Rate.SharedKernel.Contracts;
using LucasRosinelli.Rate.SharedKernel.Events;

namespace LucasRosinelli.Rate.ApplicationService
{
    public class ApplicationServiceBase
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;

        public ApplicationServiceBase(IUnitOfWork unitOfWork, IHandler<DomainNotification> notifications)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = notifications;
        }

        public bool Commit()
        {
            if (this._notifications.HasNotifications())
            {
                return false;
            }

            this._unitOfWork.Commit();
            return true;
        }
    }
}
