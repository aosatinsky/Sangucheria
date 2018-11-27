using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
    public class Venta
    {
        public int id { get; set; }
        public List<LineaDeVenta> ventas { get; set; }
        public DateTime Fecha { get; set; }
        public int activa { get; set; } = 0;
        public Cliente Cliente { get; set; }
        public int Caja { get; set; }
        public int Turno { get; set; }

        public Venta()
        {
            ventas = new List<LineaDeVenta>();
        }

        public double calcularTotal()
        {
            double total = 0;
            foreach (var item in ventas)
            {
                total += item.SubTotal;
            }

            return total;
        }

        public bool AgregarProducto(Producto p)
        {

            if ((ventas.Find(item => item.Nombre.Equals(p.Nombre)) == null || p.Agregados.Count != 0) && ComprobarProducto(p))
            {
                List<Producto> agregados = new List<Producto>();
                p.Agregados.ForEach(c => agregados.Add(c));
                ventas.Add(new LineaDeVenta()
                {
                    Nombre = p.Nombre,
                    Cantidad = 1,
                    PrecioUnitario = p.GetPrecio(),
                    prod = new Producto
                    {
                        Nombre = p.Nombre,
                        ID = p.ID,
                        Rubro = p.Rubro,
                        Agregados = agregados,
                        Existencia = p.Existencia,
                        Precio = p.Precio
                    }
                });
                return true;
            }
            else if (ComprobarProducto(p))
            {
                ventas.Find(item => item.Nombre.Equals(p.Nombre)).Cantidad += 1;
                return true;
            }
            else return false;
            
        }

        public bool ComprobarProducto(Producto p)
        {
            if (p.Existencia <= 0)
            {
                return false;
            }
            return true;
          
        }

        public List<LineaDeVenta> Linea()
        {
            return ventas;
        }

    }

}
