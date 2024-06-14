using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubModels
{
    public class CDMusica : ProductoMultimedia
    {
        public String UPC {  get; set; }
        public int Duracion {  get; set; }
    }
}
