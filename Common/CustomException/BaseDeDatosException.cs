using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBackend.Common.CustomException
{
    public class BaseDeDatosException : Exception
    {
        private DateTime _fecha; //Hora y fecha de cuando se genero la excepción.
        private string _mensaje; //Breve descripción de la excepción genereda.
        private MySqlException _excepcion; //Tipo de excepcion que se genero.

        public BaseDeDatosException(DateTime fecha, string mensaje, MySqlException excepcion)
        {
            _fecha = fecha;
            _mensaje = mensaje;
            _excepcion = excepcion;
        }

        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public MySqlException Excepcion { get => _excepcion; set => _excepcion = value; }
    }
}
