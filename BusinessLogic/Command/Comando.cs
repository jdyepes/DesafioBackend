using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common.Entities;

namespace WebApplicationBackend.BusinessLogic.Command
{
    /// <summary>
    /// patron de diseno comando
    /// </summary>
    public abstract class Comando
    {
        private Entidad entidad;

        public Entidad Entidad { get => entidad; set => entidad = value; }

        public abstract void Ejecutar();

        public abstract Entidad GetEntidad();

        public abstract List<Entidad> GetEntidades();
    }
}
