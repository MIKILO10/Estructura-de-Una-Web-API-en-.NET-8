using Estructura.Software.Web.API.Interfaces;
using Estructura.Software.Web.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estructura.Software.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependecyInjectionController : ControllerBase
    {
        private readonly ITransientWhoIAm transientWhoIAm;
        private readonly IScopeWhoIAm scopeWhoIAm;
        private readonly ISingletonWhoIAm singletonWhoIAm;
        private readonly IServiceWhoIAm serviceWhoIAm;

        public DependecyInjectionController(ITransientWhoIAm transientWhoIAm, IScopeWhoIAm scopeWhoIAm, ISingletonWhoIAm singletonWhoIAm, IServiceWhoIAm serviceWhoIAm)
        {
            this.transientWhoIAm = transientWhoIAm;
            this.scopeWhoIAm = scopeWhoIAm;
            this.singletonWhoIAm = singletonWhoIAm;
            this.serviceWhoIAm = serviceWhoIAm;
        }

        [HttpGet]
        public ActionResult Get() => Ok(new
        {
            ApiResponse = new
            {
                Singleton = singletonWhoIAm.TellMeYourId(),
                Scoped = scopeWhoIAm.TellMeYourId(),
                Transient = transientWhoIAm.TellMeYourId()
            },

            ServiceResponse = serviceWhoIAm.Invoke()
        });
    }
}
