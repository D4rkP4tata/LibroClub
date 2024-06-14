using LibroClubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubController.DAO
{
    public interface CDMusicaDAO
    {
        int insertar(CDMusica cd);

        List<CDMusica> lista();

        int eliminar(int id);

        int modificar(int id, CDMusica cd);
    }
}
