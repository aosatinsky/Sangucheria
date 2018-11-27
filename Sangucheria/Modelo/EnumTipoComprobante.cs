using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
    enum EnumTipoComprobante
    {
        Factura_A = 1,
        Nota_de_Débito_A = 2,
        Nota_de_Crédito_A = 3,
        Factura_B = 6,
        Nota_de_Débito_B = 7,
        Nota_de_Crédito_B = 8,
        Recibos_A = 4,
        Notas_de_Venta_al_contado_A = 5,
        Recibos_B = 9,
        Notas_de_Venta_al_contado_B = 10,
        Liquidacion_A = 63,
        Liquidacion_B = 64,
        Cta_de_Vta_y_Liquido_prod_A = 60,
        Cta_de_Vta_y_Liquido_prod_B = 61,
        Factura_C = 11,
        Nota_de_Débito_C = 12,
        Nota_de_Crédito_C = 13,
        Recibo_C = 15,
        Comprobante_de_Compra_de_Bienes_Usados_a_Consumidor_Final = 49,
        Factura_M = 51,
        Nota_de_Débito_M = 52,
        Nota_de_Crédito_M = 53,
        Recibo_M = 54,
    }
}
