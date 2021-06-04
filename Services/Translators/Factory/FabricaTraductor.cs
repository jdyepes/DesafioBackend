using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBackend.Services.Translators.Factory
{
    /// <summary>
    /// Instancia la clase Traductor
    /// </summary>
    public class FabricaTraductor
    {
        /// <summary>
        /// Metodo con el cual se instancia un objeto de tipo TraductorAspirante
        /// </summary>
        /// <returns></returns>
        public static TraductorAspirante CrearTraductorAspirante()
        {
            return new TraductorAspirante();
        }
    }
}
