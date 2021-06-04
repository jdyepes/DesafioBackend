using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApplicationBackend.BusinessLogic.Command.Aspirante;
using WebApplicationBackend.BusinessLogic.Factory;
using WebApplicationBackend.Common;
using WebApplicationBackend.Common.Entities;
using WebApplicationBackend.Common.Entities.Factory;
using WebApplicationBackend.Common.Resources;
using WebApplicationBackend.Services.DTO;
using WebApplicationBackend.Services.Translators;
using WebApplicationBackend.Services.Translators.Factory;

namespace WebApplicationBackend.Controllers
{
       
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [SwaggerTag("Inscripciones de aspirantes - Operaciones CRUD")]
    public class AspiranteController : ControllerBase
    {
        /// <summary>
        /// Obtiene toda la lista de los aspirantes ingresados
        /// </summary>
        /// <returns cref="Aspirante"></returns>
        /// <remarks>
        /// Obtiene toda la lista de los aspirantes ingresados
        /// </remarks>                             
        /// <response code="200" cref="Aspirante">OK. Devuelve la lista de aspirantes ingresados.</response>        
        /// <response code="404" cref="Aspirante">NotFound. No se ha encontrado el objeto solicitado.</response>        
        /// <response code="500" cref="Aspirante">InternalServerError. Ha ocurrido un error interno dentro del servidor.</response>        
        // GET: api/<AspiranteController>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]   
        public ActionResult<Aspirante> GetAll()
        {
            try
            {              
                ComandoConsultarAspirante comando = FabricaComando.CrearComandoConsultarTodosAspirante();
                comando.Ejecutar();

                TraductorAspirante traductor = FabricaTraductor.CrearTraductorAspirante();

                List<Entidad> aspirantes = comando.GetEntidades();
                List<DTOAspiranteConsulta> dtoAspirantes = traductor.CrearListaDto(aspirantes);
                return Ok(dtoAspirantes);
            }
            catch(Exception ex) //todo manejo de excepciones personalizadas
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Registra un aspirante
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Registra un aspirante
        /// </remarks>                             
        /// <response code="200" cref="DTOAspirante">OK. Operacion exitosa.</response>               
        /// <response code="500" cref="DTOAspirante">InternalServerError. Ha ocurrido un error interno dentro del servidor.</response>        
        // POST api/<AspiranteController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] DTOAspirante value)
        {
            try
            {
                // Convierte DTOAspirante a Entidad para mapear los datos
                TraductorAspirante traductor = FabricaTraductor.CrearTraductorAspirante();
                Entidad aspirante = traductor.CrearEntidad(value);

                #region Valida que solo sea con Solo 4 posibles opciones: "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin")
                ComandoValidarNombreCasa cmdValidarNombreCasa = FabricaComando.CrearComandoValidarNombreCasa(value.NombreCasa);
                cmdValidarNombreCasa.Ejecutar();
                bool valido = cmdValidarNombreCasa.GetEstatus();
                if (!valido)
                {
                    return StatusCode(400, string.Format(MensajeRespuesta.CampoNoPermitido, value.NombreCasa));
                }
                #endregion

                ComandoCrearAspirante comando = FabricaComando.CrearComandoCrearAspirante(aspirante);
                comando.Ejecutar();               

                bool exitoso = comando.GetEstatus();
                return Ok(exitoso);
            }
            catch (Exception ex) //todo manejo de excepciones personalizadas
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un aspirante dado su numero de identificacion
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Actualiza un aspirante dado su numero de identificacion
        /// </remarks>                             
        /// <response code="200" cref="DTOAspirante">OK. Operacion exitosa.</response>  
        /// <response code="400" cref="DTOAspirante">BadRequest. El formato ingresado no es valido.</response> 
        /// <response code="500" cref="DTOAspirante">InternalServerError. Ha ocurrido un error interno dentro del servidor.</response>        
        // PUT api/<AspiranteController>/5
        [HttpPut("{idParam}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(int idParam, [FromBody] DTOAspirante value)
        {
            try
            {
                if (idParam != 0)
                {
                    Aspirante asp = FabricaEntidad.CrearAspirante();
                    asp.Identificacion = idParam; // se eliminara por el numero de identificacion

                    // Convierte DTOAspirante a Entidad para mapear los datos
                    TraductorAspirante traductor = FabricaTraductor.CrearTraductorAspirante();
                    Entidad aspirante = traductor.CrearEntidad(value);

                    #region Valida que solo sea con Solo 4 posibles opciones: "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin")
                    ComandoValidarNombreCasa cmdValidarNombreCasa = FabricaComando.CrearComandoValidarNombreCasa(value.NombreCasa);
                    cmdValidarNombreCasa.Ejecutar();
                    bool valido = cmdValidarNombreCasa.GetEstatus();
                    if (!valido)
                    {
                        return StatusCode(400, string.Format(MensajeRespuesta.CampoNoPermitido, value.NombreCasa));
                    }
                    #endregion

                    ComandoActualizarAspirante comando = FabricaComando.CrearComandoActualizarAspirante(aspirante);
                    comando.Ejecutar();
                    bool exitoso = comando.GetEstatus();
                    return Ok(exitoso);
                }
                else
                {
                    return StatusCode(400, MensajeRespuesta.ParametroInvalido);
                }
            }
            catch (Exception ex) //todo manejo de excepciones personalizadas
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Elimina un aspirante
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Elimina un aspirante
        /// </remarks>                             
        /// <response code="200" cref="DTOAspirante">OK. Operacion exitosa.</response>  
        /// <response code="400" cref="DTOAspirante">BadRequest. El formato ingresado no es valido.</response> 
        /// <response code="404" cref="DTOAspirante">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500" cref="DTOAspirante">InternalServerError. Ha ocurrido un error interno dentro del servidor.</response>        
        // DELETE api/<AspiranteController>/5
        [HttpDelete("{idParam}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int idParam)
        {
            try
            {
                if (idParam != 0)
                {
                    ComandoEliminarAspirante comando = FabricaComando.CrearComandoEliminarAspirante(idParam);
                    comando.Ejecutar();
                    bool exitoso = comando.GetEstatus();
                    return Ok(exitoso);
                }
                else
                {
                    return StatusCode(400, MensajeRespuesta.ParametroInvalido);
                }
            }
            catch (Exception ex) //todo manejo de excepciones personalizadas
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
