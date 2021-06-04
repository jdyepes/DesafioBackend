using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common.Entities;

namespace WebApplicationBackend.Data.DAO.Interface
{
    /// <summary>
    /// Plantillas para las operaciones CRUD sobre Aspirante
    /// </summary>
    public interface IDAOAspirante
    {
        // create
        bool AgregarAspirante(Entidad aspirante);

        // read all - obtiene todos los aspirantes
        List<Entidad> ObtenerAspirantes();

        // update
        bool ActualizarAspirante(Entidad aspirante);

        // delete
        bool EliminarAspirantePorId(int identificacion);
    }
}
