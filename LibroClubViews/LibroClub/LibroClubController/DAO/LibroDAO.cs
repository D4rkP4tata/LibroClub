using LibroClubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubController.DAO
{
    public interface LibroDAO
    {
        int insertar(Libro libro);

        List<Libro> lista();

        int eliminar(int id);

        int modificar(int id, Libro libro);
    }
}
