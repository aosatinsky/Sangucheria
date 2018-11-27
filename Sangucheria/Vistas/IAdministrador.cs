using Sangucheria.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Vistas
{
    interface IAdministrador
    {
        string TotalManana { get; set; }
        string TotalTarde { get; set; }
    }
}
