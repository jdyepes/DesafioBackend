using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common.CustomException;
using WebApplicationBackend.Common.Resources;

namespace WebApplicationBackend.Data.DAO
{
    public class DAO
    {

        private MySqlConnection _con;
        private MySqlCommand _command;
        private DataTable _dataTable;
        private string _cadena;
        private int _cantidadRegistros;

        private readonly IConfiguration _configuration;       

        public DAO()
        {
            CrearStringConexion();
        }

        public int cantidadRegistros
        {
            get { return _cantidadRegistros; }
        }

        /// <summary>
        ///  Busca el string de conexión a la base de datos en el archivo web.config, dicho string se llama "postgrestring"
        /// </summary>
        private void CrearStringConexion()
        {
            #region parametros de conexion de la base de datos

            //nombre o ip del servidor         
            var servidor = Startup.Servidor;
            // nombre de la bd
            var nombreBd = Startup.NombreBD; 
            // usuario root por defecto
            var usuario = Startup.NombreUsuario;
            var password = Startup.Password;
            // puerto 3307
            var puerto = Startup.Puerto;

            #endregion

            _cadena = "database=" + nombreBd + ";datasource=" + servidor + ";username=" + usuario + ";password=" + password + ";port=" + puerto + ";";

        }

        private bool IsConnected()
        {
            if (_con == null)
                return false;

            if (_con.State == ConnectionState.Open)
                return true;

            return false;
        }

        public bool Conectar()
        {
            bool res = false;
            try
            {
                _con = new MySqlConnection(_cadena);
                _con.Open();
                res = true;
            }
            catch (MySqlException e)
            {
                throw new BaseDeDatosException(DateTime.Now, MensajeRespuesta.ConexionFallida, e);      
            }
            catch (Exception e)
            {
                throw new ExcepcionGeneral(DateTime.Now, e);
            }
            return res;
        }

        public void Desconectar()
        {
            if (_con != null && IsConnected())
                _con.Close();
        }

        /// <summary>
        /// Ejecutar el StoredProcedure con un valor de retorno (ResultSet), habilita el uso de las funciones "GetInt, GetString, etc" y devuelve un objeto DataTable.
        /// </summary>
        public DataTable EjecutarReader()
        {

            try
            {
                if (!IsConnected())
                    return null;

                _dataTable = new DataTable();
                _dataTable.Load(_command.ExecuteReader());
                _cantidadRegistros = _dataTable.Rows.Count;

            }
            catch (Exception exc)
            {
                throw new ArgumentNullException("Error al ejecutar el StoredProcedure " + exc);
            }
            finally
            {
                Desconectar();
            }

            return _dataTable;
        }


        /// <summary>
        /// Ejecutar el StoredProcedure sin valor de retorno (ResultSet), devuelve el número de filas afectadas.
        /// </summary>
        public int EjecutarQuery()
        {
            try
            {
                if (!IsConnected())
                    return 0;

                int filasAfectadas = _command.ExecuteNonQuery();

                return filasAfectadas;
            }
            catch (Exception exc)
            {
                throw new ArgumentNullException("Error al ejecutar el StoredProcedure " + exc);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Crea el comando para ejecutar el StoredProcedure, Ejemplo: StoredProcedure("nombreSP(@param)")
        /// </summary>
        public MySqlCommand StoredProcedure(string sp)
        {
            try
            {
                if (!IsConnected())
                    return null;

                _command = new MySqlCommand(sp, _con);
                _command.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception e)
            {
                throw e;
            }

            return _command;
        }

        public void AgregarParametro(string nombre, object valor)
        {
            try
            {
                _command.Parameters.Add(new MySqlParameter("@" + nombre, valor));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetInt(int fila, int columna)
        {
            try
            {
                int intItem = Convert.ToInt32(_dataTable.Rows[fila][columna]);

                return intItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public char GetChar(int fila, int columna)
        {
            try
            {
                char charItem = Convert.ToChar(_dataTable.Rows[fila][columna]);

                return charItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public string GetString(int fila, int columna)
        {
            try
            {
                string stringItem = Convert.ToString(_dataTable.Rows[fila][columna]);

                return stringItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public double GetDouble(int fila, int columna)
        {
            try
            {
                double doubleItem = Convert.ToDouble(_dataTable.Rows[fila][columna]);

                return doubleItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public decimal GetDecimal(int fila, int columna)
        {
            try
            {
                decimal decimalItem = Convert.ToDecimal(_dataTable.Rows[fila][columna]);

                return decimalItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool GetBool(int fila, int columna)
        {
            try
            {
                bool boolItem = Convert.ToBoolean(_dataTable.Rows[fila][columna]);

                return boolItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public DateTime GetDateTime(int fila, int columna)
        {
            try
            {
                DateTime dateItem = Convert.ToDateTime(_dataTable.Rows[fila][columna]);

                return dateItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public byte[] GetByte(int fila, int columna)
        {
            try
            {
                byte[] dateItem = (byte[])_dataTable.Rows[fila][columna];

                return dateItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
