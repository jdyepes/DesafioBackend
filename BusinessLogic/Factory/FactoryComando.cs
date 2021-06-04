using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.BusinessLogic.Command.Aspirante;
using WebApplicationBackend.Common.Entities;

namespace WebApplicationBackend.BusinessLogic.Factory
{
    /// <summary>
    /// Patron Fabrica utilizado para Comando respectivo a cada operacion
    /// CRUD
    /// </summary>
    public static class FabricaComando
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aspirante"></param>
        /// <returns></returns>
        public static ComandoCrearAspirante CrearComandoCrearAspirante(Entidad aspirante)
        {
            return new ComandoCrearAspirante(aspirante);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aspirante"></param>
        /// <returns></returns>
        public static ComandoActualizarAspirante CrearComandoActualizarAspirante(Entidad aspirante)
        {
            return new ComandoActualizarAspirante(aspirante);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ComandoConsultarAspirante CrearComandoConsultarTodosAspirante()
        {
            return new ComandoConsultarAspirante();
        }

        /// <summary>
        /// Realiza la instancia del comando que elimina el aspirante mediante su numero de identificacion
        /// </summary>
        /// <param name="numAspirante"></param>
        /// <returns></returns>
        public static ComandoEliminarAspirante CrearComandoEliminarAspirante(int numAspirante)
        {
            return new ComandoEliminarAspirante(numAspirante);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreCasa"></param>
        /// <returns></returns>
        public static ComandoValidarNombreCasa CrearComandoValidarNombreCasa(string nombreCasa)
        {
            return new ComandoValidarNombreCasa(nombreCasa);
        }
    }
}
