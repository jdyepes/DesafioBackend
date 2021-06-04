using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Services.DTO;

namespace WebApplicationBackend.Services.Factory
{
    /// <summary>
    /// Patron fabrica para instancia de los DTO
    /// </summary>
    public class FabricaDTO
    {
        /// <summary>
        /// Llama al constructor para obtener los datos de aspirante
        /// </summary>
        /// <param name="identificacion"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="nombreCasa"></param>
        /// <param name="fechaCreacion"></param>
        /// <param name="fechaModifcacion"></param>
        /// <returns></returns>
        public static DTOAspiranteConsulta CrearDTOAspiranteConsulta(int identificacion, string nombre,string apellido, 
                                                        int edad, string nombreCasa, DateTime fechaCreacion, DateTime fechaModifcacion )
        {
            return new DTOAspiranteConsulta(identificacion, nombre, apellido, edad, nombreCasa, fechaCreacion, fechaModifcacion);
        }

    }
}
