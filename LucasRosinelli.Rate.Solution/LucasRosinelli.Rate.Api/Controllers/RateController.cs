using LucasRosinelli.Rate.Domain.Contracts.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace LucasRosinelli.Rate.Api.Controllers
{
    /// <summary>
    /// Rate controller.
    /// </summary>
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        #region Field

        /// <summary>
        /// Reference statistic business intelligence.
        /// </summary>
        private readonly IReferenceStatisticApplicationService _referenceStatisticApplicationService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes rate controller.
        /// </summary>
        /// <param name="referenceStatisticApplicationService">Reference statistic business intelligence.</param>
        public RateController(IReferenceStatisticApplicationService referenceStatisticApplicationService)
        {
            this._referenceStatisticApplicationService = referenceStatisticApplicationService;
        }

        #endregion

        #region Method

        /* Defining HTTP method GET as an empty template allow us to use the route
         * "MandatoryControllerOptionalAction" mapped at Startup; Route template
         * associates the value received to our parameter which is read from query
         * string; 1 hour caching varying by currencyPair query string.
         */
        /// <summary>
        /// Gets the rate of a currency pair.
        /// </summary>
        /// <param name="currencyPair">Currency pair.</param>
        /// <returns>Rate.</returns>
        [HttpGet("")]
        [Route("{currencyPair}")]
        [ResponseCache(VaryByQueryKeys = new string[] { "currencyPair" }, Duration = 30)]
        public decimal Get([FromQuery]string currencyPair)
        {
            var result = this._referenceStatisticApplicationService.GetRate(currencyPair);

            return base.CreateResponse(result);
        }

        #endregion
    }
}