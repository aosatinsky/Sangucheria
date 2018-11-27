using Sangucheria.Modelo;
using Sangucheria.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Presentador
{
    class MainPresentador
    {
        IMain vista;

        public MainPresentador(IMain vista)
        {
            this.vista = vista;
        }

        public void AbrirPedidos()
        {
            try
            {
                if (Negocio.Loguearse(vista.user, vista.passw))
                {
                    Negocio.caja.Numero = vista.caja;
                    Negocio.caja.Turno = vista.turno;

                    Pedidos vista2 = new Pedidos();
                    vista2.Show();
                }

            }
            catch (Exception)
            {

             
            }
            
           
        }

        public void AbrirAdministrador()
        {
            try
            {
                var usuario = Negocio.usuarios.Where(u => u.User == vista.user && u.Passw == vista.passw && u.Admin == true).First();
                if (usuario != null)
                {
                    Administrador vista2 = new Administrador();
                    vista2.Show();
                }
            }
            catch (Exception)
            {

                
            }
           

        }
    }
}
