using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubModels
{
    public class Pelicula : ProductoMultimedia
    {
        public int Duracion {  get; set; }
        public String Clasificacion {  get; set; }
        public String IMBD {  get; set; }
    }
}
