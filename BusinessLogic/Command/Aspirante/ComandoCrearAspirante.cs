using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common.Entities;
using WebApplicationBackend.Data.DAO;
using WebApplicationBackend.Data.Factory;

namespace WebApplicationBackend.BusinessLogic.Command.Aspirante
{
    public class ComandoCrearAspirante : Comando
    {
        private Entidad _aspirante;
        private bool _exitoso;
        private DAOAspirante _dao;

        public ComandoCrearAspirante(Entidad aspirante)
        {
            this._aspirante = aspirante;
        }

        /// <summary>
        /// Realiza el llamado para la creacion del aspirante por el numero de indentificacion
        /// </summary>
        public override void Ejecutar()
        {
            _dao = FabricaDao.CrearDAOAspirante();
            _exitoso = _dao.AgregarAspirante(_aspirante);
        }

        /// <summary>
        /// Se obtiene el estado resultante de la operacion de registrar aspirante
        /// </summary>
        /// <returns></returns>
        public bool GetEstatus()
        {
            return _exitoso;
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}
