using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubModels
{
    public class Libro : ProductoMultimedia
    {
        public String Autor {  get; set; }
        public String ISBN {  get; set; }
        public String Editorial {  get; set; }

    }
}
