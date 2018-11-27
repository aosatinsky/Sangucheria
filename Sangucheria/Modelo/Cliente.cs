using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
    public class Cliente
    {
        public EnumTipoDoc TipoDoc { get; set; }
        public long Doc { get; set; }
        public EnumCondicionTributaria CondicionTributaria { get; set; }
    }
}
