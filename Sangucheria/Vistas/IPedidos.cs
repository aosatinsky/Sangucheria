using Sangucheria.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Vistas
{
    interface IPedidos
    {
        List<LineaDeVenta> lineaDeVentas { get; set; }
        List<Producto> productos { get; set; }
        Producto producto { get; set; }
        LineaDeVenta lineaDeVenta { get; set; }
        string total { get; set; }
        List<Cliente> clientes { get; set; }
        Cliente cliente { get; set; }
        

    }
}
