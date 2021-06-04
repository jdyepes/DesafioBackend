using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common.Const;
using WebApplicationBackend.Common.Entities;

namespace WebApplicationBackend.BusinessLogic.Command.Aspirante
{
    public class ComandoValidarNombreCasa : Comando
    {

        private bool _exitoso;
        private string _nombreCasa;

        public ComandoValidarNombreCasa(string nombreCasa)
        {
            this._nombreCasa = nombreCasa;
        }

        /// <summary>
        /// Valida el nombre de Casa a la que aspira pertenecer 
        /// (Solo 4 posibles opciones: "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin")
        /// Sin importar mayusculas
        /// </summary>
        public override void Ejecutar()
        {
            string nombre = this._nombreCasa;
            if (nombre.Equals(HomeTypes.Gryffindor, StringComparison.OrdinalIgnoreCase) || nombre.Equals(HomeTypes.Hufflepuff, StringComparison.OrdinalIgnoreCase) || 
                nombre.Equals(HomeTypes.Ravenclaw, StringComparison.OrdinalIgnoreCase) || nombre.Equals(HomeTypes.Slytherin, StringComparison.OrdinalIgnoreCase))
            {
                this._exitoso = true;
            }
            else
            {
                this._exitoso = false;
            }
        }

        /// <summary>
        /// Se obtiene el estado resultante de la operacion
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
