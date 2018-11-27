using Sangucheria.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sangucheria.Modelo;

namespace Sangucheria.Presentador
{
    class AdministradorPresentador
    {
        IAdministrador vista;
        public AdministradorPresentador(IAdministrador vista)
        {
            this.vista = vista;
        }

       

        public void TotalRecaudado()
        {

            vista.TotalManana = Negocio.TotalRecaudadoMan().ToString();

            foreach (var item in Negocio.caja.GetVentas().Where(u => u.Turno == 1))
            {
                vista.TotalTarde += item.calcularTotal();

            }
        }

       

    }
}
