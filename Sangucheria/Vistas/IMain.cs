using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Vistas
{
    interface IMain
    {
        int caja { get; set; }
        string passw { get; set; }
        string user { get; set; }
        int turno { get; set; }
    }
}
