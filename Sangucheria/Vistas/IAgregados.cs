using Sangucheria.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Vistas
{
    interface IAgregados
    {
        List<Producto> Agregados { get; set; }
        List<Producto> NuevoAgregado { get; set; }
        Producto Producto { get; set; }
        Producto Agregar { get; set; }

    }
}
