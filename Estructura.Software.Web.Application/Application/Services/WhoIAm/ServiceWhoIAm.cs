using Estructura.Software.Web.Application.Application.Interfaces.IWhoIAm;

namespace Estructura.Software.Web.Application.Application.Services.WhoIAm
{
    public interface IServiceWhoIAm
    {
        dynamic Invoke();
    }
    public class ServiceWhoIAm : IServiceWhoIAm
    {
        private readonly ITransientWhoIAm transientWhoIAm;
        private readonly IScopeWhoIAm scopeWhoIAm;
        private readonly ISingletonWhoIAm singletonWhoIAm;

        public ServiceWhoIAm(ITransientWhoIAm transientWhoIAm, IScopeWhoIAm scopeWhoIAm, ISingletonWhoIAm singletonWhoIAm)
        {
            this.transientWhoIAm = transientWhoIAm;
            this.scopeWhoIAm = scopeWhoIAm;
            this.singletonWhoIAm = singletonWhoIAm;
        }



        public dynamic Invoke() => new
        {
            Singleton = singletonWhoIAm.TellMeYourId(),
            Scoped = scopeWhoIAm.TellMeYourId(),
            Transient = transientWhoIAm.TellMeYourId()
        };
    }
}
