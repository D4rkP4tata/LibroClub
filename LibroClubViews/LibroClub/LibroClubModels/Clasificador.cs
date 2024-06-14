using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubModels
{
    public class Clasificador
    {
        public int ID_Clasificador {  get; set; }
        public int Cantidad {  get; set; }
        public string Nombre {  get; set; }
        public TipoClasificador Tipo {  get; set; }
    }
}
