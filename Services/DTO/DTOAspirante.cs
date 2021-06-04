using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBackend.Services.DTO
{
    /// <summary>
    /// Clase que representa Aspirante. En este caso se mantiene todo igual
    /// </summary>
    public class DTOAspirante
    {
     
        private int _identificacion;
      
        private string _nombre;
    
        private string _apellido;

        private int _edad;
        
        private string _nombreCasa;

        public DTOAspirante(int identificacion, string nombre, string apellido, int edad, 
                                string nombreCasa, DateTime fechaCreacion, DateTime fechaModificacion)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            NombreCasa = nombreCasa;
        }

        public int Identificacion { get => _identificacion; set => _identificacion = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int Edad { get => _edad; set => _edad = value; }
        public string NombreCasa { get => _nombreCasa; set => _nombreCasa = value; }

    }
}
