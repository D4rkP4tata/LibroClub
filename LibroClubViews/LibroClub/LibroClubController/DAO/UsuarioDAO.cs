using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibroClubModels;

namespace LibroClubController.DAO
{
	public interface UsuarioDAO
	{
		int insertar(Usuario usuario);

		List<Usuario> listar();

		int eliminar(int id);

		int modificar(int id, String dni, String nombre, DateTime fecha_nacimiento,
			char genero, int telefono, int tipo_membresia);
	}
}
