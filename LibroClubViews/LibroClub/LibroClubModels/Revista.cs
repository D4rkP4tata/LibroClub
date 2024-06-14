using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubModels
{
    public class Revista : ProductoMultimedia
    {
        public String Editor {  get; set; }
        public String ISSN {  get; set; }
    }
}
