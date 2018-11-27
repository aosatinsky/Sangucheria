using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
   public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public enumRubros Rubro { get; set; }
        public float Existencia { get; set; }
        public List<Producto> Agregados { get; set; } = new List<Producto>();
        public float Precio { get; set; }

        public float GetPrecio()
        {
            if (Agregados != null)
            {
                float subtotal = 0;
                foreach (var item in Agregados)
                {
                    subtotal += item.Precio;
                }
                subtotal += Precio;
                return subtotal;
            }
            else return Precio;
        }
    }


}
