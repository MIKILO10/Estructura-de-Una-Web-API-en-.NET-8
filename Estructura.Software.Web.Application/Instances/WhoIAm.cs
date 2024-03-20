using Estructura.Software.Web.Application.Application.Interfaces.IWhoIAm;

namespace Estructura.Software.Web.API.Instances
{
    public class WhoIAm : IScopeWhoIAm, ITransientWhoIAm, ISingletonWhoIAm
    {
        private readonly int Identificator;

        public WhoIAm()
        {
            Identificator = new Random().Next(0, 10);
        }
        public string TellMeYourId()
        {
            return $"Soy la instancia {Identificator}";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
        }
    }
}
