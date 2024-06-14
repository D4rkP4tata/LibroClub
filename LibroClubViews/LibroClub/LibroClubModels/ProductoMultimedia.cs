using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubModels
{
    public abstract class ProductoMultimedia
    {
        public int ID_Producto { get; set; }  
        public int StockVenta { get; set; }
        public String Titulo {  get; set; }
        public int StockPrestamo { get; set; }
        public double Precio { get; set; }
        public int StockDisponiblePrestamo { get; set; }
        public Clasificador Clasificador { get; set; }
    }
}
