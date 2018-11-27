using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
    class Comprobante
    {
        //Cabecera
        public TPDV Caja { get; set; }
        public int CantRegistros { get; set; } = 1;

        //Detalle
        public int Concepto { get; set; } = 1; // 1 productos 2 servicios
        public Venta venta { get; set; }

        public string Cae { get; set; }

        public EnumTipoComprobante TipoComprobante
        {
            get
            {
                if (venta.Cliente.CondicionTributaria == Negocio.CondicionTributaria)
                {
                    return EnumTipoComprobante.Factura_A;
                }
                else if(Negocio.CondicionTributaria == EnumCondicionTributaria.RESPONSABLE_INSCRIPTO
                    && (venta.Cliente.CondicionTributaria == EnumCondicionTributaria.MONOTRIBUTISTA ||
                venta.Cliente.CondicionTributaria == EnumCondicionTributaria.CONSUMIDOR_FINAL))
                {
                    return EnumTipoComprobante.Factura_B;
                }
                else
                {
                    return EnumTipoComprobante.Factura_C;
                }
            }
            
        }


    }
}
