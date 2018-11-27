using Sangucheria.Modelo;
using Sangucheria.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Presentador
{
    class AgregadosPresentador
    {
        IAgregados vista;

        public AgregadosPresentador(IAgregados vista)
        {
            this.vista = vista;
        }

        public void CargarAgregados()
        {
            vista.Agregados = Negocio.productos.Where(u => u.Rubro == enumRubros.Agregado).ToList();
        }

        public void Agregar(Producto prod)
        {
            prod.Agregados.Add(vista.Agregar);
        }

        public void BorrarAgregado(Producto prod)
        {
            Producto p = vista.Producto;
            vista.NuevoAgregado = null;
            prod.Agregados.Remove(p);
            vista.NuevoAgregado = prod.Agregados;
        }

    }
}
