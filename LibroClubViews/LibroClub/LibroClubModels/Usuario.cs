using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubModels
{
	public class Usuario: Persona
	{
		public int ID_Usuario { get; set; }
		public DateTime FechaAfiliacion { get; set; }
		public int Id_TipoClasificador { get; set; }
		public int Id_Producto { get; set; }
		public int Id_Membresia { get; set; }

		public Persona Persona { get; set; }
		public TipoMembresia TipoMembresia { get; set; }
	}
}
