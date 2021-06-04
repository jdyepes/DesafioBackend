using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common;
using WebApplicationBackend.Common.Entities;
using WebApplicationBackend.Common.Entities.Factory;
using WebApplicationBackend.Services.DTO;
using WebApplicationBackend.Services.Factory;

namespace WebApplicationBackend.Services.Translators
{
    /// <summary>
    /// Clase con el fin de convertir el respose Entidad a Aspirante
    /// </summary>
    public class TraductorAspirante
    {
        /// <summary>
        /// Metodo con el cual se transforma una entidad en un DTOAsirante
        /// </summary>
        /// <param name="entidad">Entidad que se desea transformar</param>
        /// <returns></returns>
        public DTOAspiranteConsulta CrearDto(Entidad entidad)
        {
            try
            {
                Aspirante aspirante = entidad as Aspirante;
                DTOAspiranteConsulta dto;

                dto = FabricaDTO.CrearDTOAspiranteConsulta(
                        aspirante.Identificacion, 
                        aspirante.Nombre,
                        aspirante.Apellido,
                        aspirante.Edad,
                        aspirante.NombreCasa,
                        aspirante.FechaCreacion,
                        aspirante.FechaModificacion);

                return dto;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Metodo con el cual se transforma un DTOAspirante a una Entidad Aspirante
        /// </summary>
        /// <remarks> No se indica en el dto la fechaCreacion ni fechaModificacion</remarks>
        /// <param name="dto">Objeto dto que se desea transformar</param>
        /// <returns></returns>
        public Entidad CrearEntidad(DTOAspirante dto)
        {
            try
            {
                Entidad aspirante = FabricaEntidad.CrearAspirante(
                        dto.Identificacion,
                        dto.Nombre,
                        dto.Apellido,
                        dto.Edad,
                        dto.NombreCasa);

                return aspirante;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo con el cual se transforma de una lista de entidades a una lista de dtos
        /// </summary>
        /// <param name="entidades">Lista de entidades que se va a transformar</param>
        /// <returns></returns>
        public List<DTOAspiranteConsulta> CrearListaDto(List<Entidad> entidades)
        {
            try
            {
                List<DTOAspiranteConsulta> dtos = new List<DTOAspiranteConsulta>();

                foreach (Entidad aspirante in entidades)
                {
                    dtos.Add(CrearDto(aspirante));
                }

                return dtos;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
