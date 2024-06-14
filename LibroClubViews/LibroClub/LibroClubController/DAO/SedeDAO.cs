using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibroClubModels;

namespace LibroClubController.DAO
{
	public interface SedeDAO
	{
		int insertar(Sede sede);

		List<Sede> lista();

		int eliminar(int id);

		int modificar(int id, String direccion);
	}
}
