using Microsoft.AspNetCore.Mvc;

namespace LucasRosinelli.Rate.Api.Controllers
{
    [Route("[controller]")]
    public class RateController : Controller
    {
        // Defining HTTP method GET as an empty template allow us to use the route "MandatoryControllerOptionalAction" mapped at Startup;
        // Route template associates the value received to our parameter which is read from query string.
        [HttpGet("")]
        [Route("{currencyPair}")]
        public decimal Get([FromQuery]string currencyPair)
        {
            return 0.123456M;
        }
    }
}