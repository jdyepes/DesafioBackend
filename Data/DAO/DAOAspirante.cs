using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common;
using WebApplicationBackend.Common.Entities;
using WebApplicationBackend.Common.Entities.Factory;
using WebApplicationBackend.Data.DAO.Interface;

namespace WebApplicationBackend.Data.DAO
{
    public class DAOAspirante : DAO, IDAOAspirante
    {    
        /// <summary>
        /// Actualiza el aspirante de acuerdo a su numero de identificacion
        /// </summary>
        /// <param name="aspirante"></param>
        /// <returns></returns>
        public bool ActualizarAspirante(Entidad _aspirante)
        {
            bool exitoso = false; //flag para indicar estado de insercion en la BD

            try
            {
                Aspirante aspirante = _aspirante as Aspirante;

                Conectar();

                StoredProcedure("sp_AspiranteUpdate");

                AgregarParametro("_identificacion", aspirante.Identificacion);
                AgregarParametro("_nombre", aspirante.Nombre);
                AgregarParametro("_apellido", aspirante.Apellido);
                AgregarParametro("_edad", aspirante.Edad);
                AgregarParametro("_nombreCasa", aspirante.NombreCasa);

                EjecutarQuery();
                exitoso = true;
            }
            catch (Exception ex)
            {
                exitoso = false;
            }

            return exitoso;
        }

        /// <summary>
        /// Agrega el objeto Aspirante con sus datos pasando por Entidad
        /// </summary>
        /// <param name="aspirante"></param>
        /// <returns></returns>
        public bool AgregarAspirante(Entidad _aspirante)
        {
            bool exitoso = false; //flag para indicar estado de insercion en la BD

            try
            {           
                Aspirante aspirante = _aspirante as Aspirante;

                Conectar();

                StoredProcedure("sp_AspiranteCreate");

                AgregarParametro("_identificacion", aspirante.Identificacion);
                AgregarParametro("_nombre", aspirante.Nombre);
                AgregarParametro("_apellido", aspirante.Apellido);
                AgregarParametro("_edad", aspirante.Edad);
                AgregarParametro("_nombreCasa", aspirante.NombreCasa);           

                EjecutarQuery();
                exitoso = true;
            } 
            catch(Exception ex)// todo manejo de exceciones personalizadas
            {
                exitoso = false;
            }

            return exitoso;
        }

        /// <summary>
        /// Elimina el aspirannte indicando su numero de identificacion
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        public bool EliminarAspirantePorId(int identificacion)
        {
            bool exitoso = false; //flag para indicar estado de insercion en la BD

            try
            {
                Conectar();

                StoredProcedure("sp_AspiranteDelete");

                AgregarParametro("_identificacion", identificacion);

                EjecutarQuery();
                exitoso = true;
            }
            catch (Exception ex)
            {
                exitoso = false;
            }

            return exitoso;
        }

        /// <summary>
        /// Consulta todos los aspirantes
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ObtenerAspirantes()
        {
            Aspirante aspirante;

            List<Entidad> aspirantes = new List<Entidad>();          

            Conectar();

            StoredProcedure("sp_AspiranteReadAll");

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                aspirante = FabricaEntidad.CrearAspirante();               

                aspirante.Id = GetInt(i, 0); // segundo parametro indica la posicion en la columna
                aspirante.Identificacion = GetInt(i, 1);
                aspirante.Nombre = GetString(i, 2);
                aspirante.Apellido = GetString(i, 3);
                aspirante.Edad = GetInt(i, 4);
                aspirante.NombreCasa = GetString(i, 5);
                aspirante.FechaCreacion = GetDateTime(i, 6);
                aspirante.FechaModificacion = GetDateTime(i, 7);

                aspirantes.Add(aspirante);
            }

            return aspirantes;
        }
    }
}
