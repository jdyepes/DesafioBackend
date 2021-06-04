using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBackend.Common.Entities;

namespace WebApplicationBackend.Common
{
    public class Aspirante : Entidad
    {

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Numero de indentificacion ingresado no valido")]
        [MaxLength(10)]
        private int _identificacion;

        [Required]
        [StringLength(20, ErrorMessage = "El nombre del aspirante debe tener una longitud maxima de 20 caracteres.")]
        [MaxLength(20)]
        private string _nombre;

        [Required]
        [StringLength(20, ErrorMessage = "El apellido del aspirante debe tener una longitud maxima de 20 carateres.")]
        [MaxLength(20)]
        private string _apellido;

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "edad ingresada no valido")]
        [MaxLength(2)]
        private int _edad;

        [Required]
        private string _nombreCasa;

        /// <summary>
        /// Datos ingresados internamente por el servidor
        /// </summary>
        private DateTime _fechaCreacion;

        /// <summary>
        /// Datos ingresados internamente por el servidor
        /// </summary>
        private DateTime _fechaModificacion;
        private DateTime fechaModifcacion;

        public Aspirante()
        {
        }

        public Aspirante(int identificacion, string nombre, string apellido, int edad, string nombreCasa)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            NombreCasa = nombreCasa;
        }

        public Aspirante(int identificacion, string nombre, string apellido, int edad, string nombreCasa, DateTime fechaCreacion, DateTime fechaModifcacion)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            NombreCasa = nombreCasa;
            FechaCreacion = fechaCreacion;
            this.fechaModifcacion = fechaModifcacion;
        }

        public int Identificacion { get => _identificacion; set => _identificacion = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int Edad { get => _edad; set => _edad = value; }
        public string NombreCasa { get => _nombreCasa; set => _nombreCasa = value; }
        public DateTime FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }
     
    }
}
