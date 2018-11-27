using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
    public class LineaDeVenta
    {
       
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public Producto prod { get; set; }
        public double SubTotal
        {
            get { return (prod.GetPrecio() * Cantidad); }
        }
    }
}
