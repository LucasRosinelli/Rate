using LucasRosinelli.Rate.SharedKernel.Contracts;
using LucasRosinelli.Rate.SharedKernel.Events;
using Microsoft.AspNetCore.Mvc;

namespace LucasRosinelli.Rate.Api.Controllers
{
    public class ControllerBase : Controller
    {
        private IHandler<DomainNotification> _notifications;

        public IHandler<DomainNotification> Notifications
        {
            get
            {
                return this._notifications;
            }
        }

        public ControllerBase(IHandler<DomainNotification> notifications)
        {
            this._notifications = notifications;
        }

        public T CreateResponse<T>(T result)
        {
            if (this.Notifications.HasNotifications())
            {
                this.Response.StatusCode = BadRequest().StatusCode;
                return default(T);
            }

            return result;
        }
    }
}