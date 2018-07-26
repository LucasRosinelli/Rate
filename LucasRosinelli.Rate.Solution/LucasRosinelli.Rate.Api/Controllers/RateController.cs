using LucasRosinelli.Rate.Domain.Contracts.ApplicationServices;
using LucasRosinelli.Rate.SharedKernel.Contracts;
using LucasRosinelli.Rate.SharedKernel.Events;
using Microsoft.AspNetCore.Mvc;

namespace LucasRosinelli.Rate.Api.Controllers
{
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private readonly IReferenceStatisticApplicationService _referenceStatisticApplicationService;

        public RateController(IReferenceStatisticApplicationService referenceStatisticApplicationService, IHandler<DomainNotification> notifications)
            : base(notifications)
        {
            this._referenceStatisticApplicationService = referenceStatisticApplicationService;
        }

        /* Defining HTTP method GET as an empty template allow us to use the route
         * "MandatoryControllerOptionalAction" mapped at Startup; Route template
         * associates the value received to our parameter which is read from query
         * string.
         */
        [HttpGet("get")]
        [Route("stuff/{currencyPair}")]
        //[ResponseCache(Duration = 60, VaryByQueryKeys = new string[] { "currencyPair" })]
        public decimal Get([FromQuery]string currencyPair)
        {
            var result = this._referenceStatisticApplicationService.GetRate(currencyPair);

            return base.CreateResponse(result);
        }
    }
}