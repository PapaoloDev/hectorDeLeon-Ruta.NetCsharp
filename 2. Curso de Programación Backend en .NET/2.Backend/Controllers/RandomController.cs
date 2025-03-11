using _2.Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        IRandomService _randomServiceSingleton;
        IRandomService _randomServiceScoped;
        IRandomService _randomServiceTransient;

        IRandomService _random2ServiceSingleton;
        IRandomService _random2ServiceScoped;
        IRandomService _random2ServiceTransient;

        public RandomController([FromKeyedServices("randomServiceSingleton")] IRandomService randomServiceSingleton,
            [FromKeyedServices("randomServiceScoped")] IRandomService randomServiceScoped,
            [FromKeyedServices("randomServiceTransient")] IRandomService randomServiceTransient,
            [FromKeyedServices("randomServiceSingleton")] IRandomService random2ServiceSingleton,
            [FromKeyedServices("randomServiceScoped")] IRandomService random2ServiceScoped,
            [FromKeyedServices("randomServiceTransient")] IRandomService random2ServiceTransient)
        {
            _randomServiceSingleton = randomServiceSingleton;
            _randomServiceScoped = randomServiceScoped;
            _randomServiceTransient = randomServiceTransient;

            _random2ServiceSingleton = random2ServiceSingleton;
            _random2ServiceScoped = random2ServiceScoped;
            _random2ServiceTransient = random2ServiceTransient;

        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            return new Dictionary<string, int>
            {
                { "Singleton", _randomServiceSingleton.Value },
                { "Scoped", _randomServiceScoped.Value },
                { "Transient", _randomServiceTransient.Value },
                { "Singleton2", _random2ServiceSingleton.Value },
                { "Scoped2", _random2ServiceScoped.Value },
                { "Transient2", _random2ServiceTransient.Value }
            };
        }
    }
}
