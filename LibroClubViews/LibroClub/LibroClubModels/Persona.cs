using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubModels
{
	public class Persona
	{
		public int ID_Persona { get; set; }
		public String DNI { get; set; }
		public String Nombre { get; set; }
		public DateTime Fecha_Nacimiento { get; set; }
		public Char Genero { get; set; }
		public int Telefono { get; set; }
			
	}
}
