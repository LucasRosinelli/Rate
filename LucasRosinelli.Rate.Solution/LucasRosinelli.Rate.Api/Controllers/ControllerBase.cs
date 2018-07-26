using LucasRosinelli.Rate.SharedKernel.Contracts;
using LucasRosinelli.Rate.SharedKernel.Events;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace LucasRosinelli.Rate.Api.Controllers
{
    /// <summary>
    /// Base controller for requests.
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        #region Field

        /// <summary>
        /// Notifications.
        /// </summary>
        private IHandler<DomainNotification> _notifications;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes controller.
        /// </summary>
        public ControllerBase()
        {
            this._notifications = (IHandler<DomainNotification>)DomainEvent.Container.GetService(typeof(IHandler<DomainNotification>));
        }

        #endregion

        #region Method

        /// <summary>
        /// Creates response validating existing notifications.
        /// </summary>
        /// <typeparam name="T">Expected type.</typeparam>
        /// <param name="result">Result to send as response, if valid.</param>
        /// <returns>Result if has no notifications; otherwise, default value.</returns>
        public T CreateResponse<T>(T result)
        {
            if (this._notifications.HasNotifications())
            {
                this.Response.StatusCode = BadRequest().StatusCode;
                var notifications = JsonConvert.SerializeObject(this._notifications.Notify());
                this.Response.Body = new MemoryStream(Encoding.ASCII.GetBytes(notifications));
                return default(T);
            }

            return result;
        }

        #endregion
    }
}