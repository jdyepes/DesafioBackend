using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBackend.Common.Entities
{
	public abstract class Entidad
	{
		private int _id;

		/// <summary>
		/// Getters y Setters de ID - Siguiendo a Entity
		/// </summary>
		public int Id { get => _id; set => _id = value; }
	}
}
