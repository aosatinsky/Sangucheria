using Sangucheria.vSoap;
using Sangucheria.Afip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sangucheria.Modelo;
using System.Configuration;


namespace Sangucheria.Adaptadores
{
    class AdaptadorAfip
    {
        public string GetCAE(Comprobante comp)
        {
            LoginService C = new LoginService();
            Autorizacion autorizacion;


            autorizacion = C.SolicitarAutorizacion("F4471E79-80A9-4AF1-88F7-704092880A88");

            FEAuthRequest AutoAfip = new FEAuthRequest();
            AutoAfip.Cuit = autorizacion.Cuit;
            AutoAfip.Sign = autorizacion.Sign;
            AutoAfip.Token = autorizacion.Token;

            Service servicio = new Service();

            FECAERequest request = new FECAERequest();
            FECAECabRequest CabeceraRequest = new FECAECabRequest();

            CabeceraRequest.CantReg = 1; //cantidad de registros
            CabeceraRequest.CbteTipo = (int) comp.TipoComprobante; //tipo de comprobante
            CabeceraRequest.PtoVta = comp.Caja.Numero; //punto de venta

            int UltimaTransaccion = servicio.FECompUltimoAutorizado(AutoAfip, comp.Caja.Numero, (int)comp.TipoComprobante).CbteNro;

            FECAEDetRequest[] DetalleComprobante = new FECAEDetRequest[1] { new FECAEDetRequest() };
            
            DetalleComprobante[0].Concepto = comp.Concepto; //1 productos 2 servicio
            DetalleComprobante[0].DocTipo = (int) comp.venta.Cliente.TipoDoc; //tipo doc 96=dni
            DetalleComprobante[0].DocNro = comp.venta.Cliente.Doc; //doc numero
            DetalleComprobante[0].CbteDesde = UltimaTransaccion + 1;
            DetalleComprobante[0].CbteHasta = UltimaTransaccion + 1;
            DetalleComprobante[0].CbteFch = DateTime.Now.ToString("yyyyMMdd");
            DetalleComprobante[0].ImpTotal = DetalleComprobante[0].ImpNeto = comp.venta.calcularTotal();
            DetalleComprobante[0].ImpTotConc = 0;
            DetalleComprobante[0].ImpOpEx = 0;
            DetalleComprobante[0].ImpIVA = 0;
            DetalleComprobante[0].ImpTrib = 0;
            DetalleComprobante[0].MonId = servicio.FEParamGetTiposMonedas(AutoAfip).ResultGet[0].Id;
            DetalleComprobante[0].MonCotiz = 1; //1 peso argentino

            request.FeCabReq = CabeceraRequest;
            request.FeDetReq = DetalleComprobante;

            FECAEResponse Respuesta = servicio.FECAESolicitar(AutoAfip, request);

            if (Respuesta.Errors!=null)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + Respuesta.Errors[0]);

            }

            return Respuesta.FeDetResp[0].CAE;

        }
        
    }
}
