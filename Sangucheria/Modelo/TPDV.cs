using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
    public class TPDV
    {
        public int Numero { get; set; }
        public int Turno { get; set; }
        public List<Venta> ventas = new List<Venta>();

        public List<Venta> GetVentas()
        {
            return ventas;
        }

    }
}
