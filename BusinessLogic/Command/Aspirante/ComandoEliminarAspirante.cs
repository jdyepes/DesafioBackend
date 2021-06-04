using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common.Entities;
using WebApplicationBackend.Data.DAO;
using WebApplicationBackend.Data.Factory;

namespace WebApplicationBackend.BusinessLogic.Command.Aspirante
{
    /// <summary>
    /// Comando para eliminar un aspirante
    /// </summary>
    public class ComandoEliminarAspirante : Comando
    {
        private int _numeroIdentificacion;
        private bool _exitoso;
        private DAOAspirante _dao;

        public ComandoEliminarAspirante(int numeroIdentificacion)
        {
            this._numeroIdentificacion = numeroIdentificacion;
        }

        /// <summary>
        /// Realiza el llamado para la eliminacion del aspirante por el numero de indentificacion
        /// </summary>
        public override void Ejecutar()
        {
            _dao = FabricaDao.CrearDAOAspirante();
            _exitoso = _dao.EliminarAspirantePorId(_numeroIdentificacion);
        }

        /// <summary>
        /// Se obtiene el estado resultante de la operacion de eliminar el aspirante por la identificacion
        /// </summary>
        /// <returns></returns>
        public bool GetEstatus()
        {
            return _exitoso;

        }
        public override Entidad GetEntidad()
        {
            throw new NotImplementedException(); // no aplica para eliminar el aspirante
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException(); // no aplica para eliminar el aspirante
        }
    }
}
