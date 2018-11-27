using Sangucheria.Adaptadores;
using Sangucheria.Modelo;
using Sangucheria.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Presentador
{
    class PedidosPresentador
    {


        IPedidos vista;
        public PedidosPresentador(IPedidos vista)
        {
            this.vista = vista;
        }

        public List<Producto> GetProductos()
        {
            return Negocio.GetProductos().Where(u => u.Rubro != enumRubros.Agregado).ToList();
        }

        public void CargarProductos()
        {
            Negocio.agregarProductos();
        }
        
        public List<Cliente> CargarClientes()
        {
            return Negocio.GetClientes();
        }

        public void AgregarProducto()
        {

            if (Negocio.caja.GetVentas().Find(item => item.activa == 1) == null)
            {
                Venta venta = new Venta() {
                    activa = 1,
                    Fecha = DateTime.Now,
                    Caja = Negocio.caja.Numero,
                    Turno = Negocio.caja.Turno
                }
                    ;
                venta.AgregarProducto(vista.producto);

                Negocio.caja.GetVentas().Add(venta);
                vista.total = Negocio.caja.GetVentas().Find(item => item.activa == 1).calcularTotal().ToString();
            }
            else
            {

                Negocio.caja.GetVentas().Find(item => item.activa == 1).AgregarProducto(vista.producto);
                vista.total = Negocio.caja.GetVentas().Find(item => item.activa == 1).calcularTotal().ToString();
                
            }




        }


       
        public void VerAgregados()
        {
            if (vista.lineaDeVenta.prod.Agregados != null)
            {
                Agregados agregados = new Agregados(vista.lineaDeVenta.prod);
                agregados.FormClosing += Agregados_FormClosing;
                agregados.Show();
            }
        }
        public void Agregados_FormClosing(object sender, EventArgs e)
        {
            vista.total = Negocio.caja.GetVentas().Find(item => item.activa == 1).calcularTotal().ToString();

        }

        public List<LineaDeVenta> GetVentaActiva()
        {
            return Negocio.caja.GetVentas().Find(item => item.activa == 1).ventas;
        }

        public void BorrarItem()
        {
            vista.lineaDeVenta.Cantidad -= 1;
            Negocio.caja.GetVentas().Find(item => item.activa == 1).ventas.RemoveAll(item => item.Cantidad == 0);
            vista.total = Negocio.caja.GetVentas().Find(item => item.activa == 1).calcularTotal().ToString();

        }

        public List<LineaDeVenta> LineaVacia()
        {
            return new List<LineaDeVenta>();
        }

        public string[] RealizarPedido()
        {
            foreach (var item in Negocio.caja.GetVentas().Find(item => item.activa == 1).ventas)
            {
                (Negocio.GetProductos().Find(item1 => item1.Nombre.Equals(item.Nombre))).Existencia -= item.Cantidad;
            }
            //afip

            Negocio.caja.GetVentas().Find(item => item.activa == 1).Cliente = vista.cliente;

            //AdaptadorAfip adp = new AdaptadorAfip();
            Comprobante comp = new Comprobante()
            {
                Caja = Negocio.caja,
                CantRegistros = 1,
                venta = Negocio.caja.GetVentas().Find(item => item.activa == 1),
                Concepto = 1
            };

            comp.Cae = "123123123123123123123123123123";
            /*adp.GetCAE(comp);*/


            
           

            Negocio.caja.GetVentas().Find(item => item.activa == 1).activa = 0;

            string[] resultados = new string[] { comp.Cae,comp.venta.calcularTotal().ToString()};
            return resultados;


        }

        

    }
}
