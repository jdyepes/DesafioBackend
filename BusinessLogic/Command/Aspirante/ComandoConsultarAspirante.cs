using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common.Entities;
using WebApplicationBackend.Data.DAO;
using WebApplicationBackend.Data.Factory;

namespace WebApplicationBackend.BusinessLogic.Command.Aspirante
{
    public class ComandoConsultarAspirante : Comando
    {

        private List<Entidad> _aspirantes;
        private DAOAspirante _dao;    

        /// <summary>
        /// Realiza el llamado para la consulta del aspirante por el numero de indentificacion
        /// </summary>
        public override void Ejecutar()
        {
            _dao = FabricaDao.CrearDAOAspirante();
            _aspirantes = _dao.ObtenerAspirantes();
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returna la lista de aspirantes del tipo Entidad
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> GetEntidades()
        {
            return _aspirantes;
        }
    }
}
