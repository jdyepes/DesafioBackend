using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBackend.Common.Entities.Factory
{
    /// <summary>
    /// Patron Fabrica
    /// </summary>
    public static class FabricaEntidad
    {
        /// <summary>
        /// Metodo que realiza una instancia de tipo aspirante : Patron Fabrica
        /// </summary>
        /// <returns></returns>
        public static Aspirante CrearAspirante()
        {
            return new Aspirante();
        }

        /// <summary>
        /// Metodo que realiza una instancia de tipo aspirante insertando los datos: Patron Fabrica
        /// </summary>
        /// <returns></returns>
        public static Aspirante CrearAspirante(int identificacion, string nombre, string apellido,
                                                       int edad, string nombreCasa)
        {
            return new Aspirante(identificacion, nombre, apellido, edad, nombreCasa);
        }
    }
}
