using LibroClubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubController.DAO
{
    public interface RevistaDAO
    {
        int insertar(Revista rev);

        List<Revista> lista();

        int eliminar(int id);

        int modificar(int id, Revista rev);
    }
}
