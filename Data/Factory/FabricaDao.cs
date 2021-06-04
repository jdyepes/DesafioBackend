using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Data.DAO;

namespace WebApplicationBackend.Data.Factory
{
    public static class FabricaDao
    {
        /// <summary>
        /// Devuelve la instancia de DAOAspirante
        /// Creado dom 30/may/2021
        /// </summary>
        /// <returns>DAOUsuario</returns>
        public static DAOAspirante CrearDAOAspirante()
        {
            return new DAOAspirante();
        }
    }
}
