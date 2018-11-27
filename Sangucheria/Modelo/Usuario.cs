using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
   public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Passw { get; set; }
        public bool Admin { get; set; }
    }
}
