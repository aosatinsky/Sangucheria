using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sangucheria.Modelo;
using System;
using System.Linq;

namespace LibreriaTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TotalEntreMilanesaYCocaDeberiaRetorna35()
        {
            //Arrange
            Negocio.agregarProductos();
            var CocaCola = Negocio.productos.Find(i => i.ID == 1);
            var Milanesa = Negocio.productos.Find(i => i.ID == 2);

            var VentaMilanesaYCoca = new Venta
            {
                Caja = 1,
                Turno = 0,
                id = 1,
                activa = 1,
                Fecha = DateTime.Today,
                Cliente = new Cliente()

            };
            VentaMilanesaYCoca.AgregarProducto(CocaCola);
            VentaMilanesaYCoca.AgregarProducto(Milanesa);


            var resultadoEsperado = 35;

            //Act
            var resultadoReal = VentaMilanesaYCoca.calcularTotal();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoReal);
                
        }

        [TestMethod]
        public void ExistenciaDeCervezaAresanalRetornaFalso()
        {

            //Arrange
            Negocio.agregarProductos();
            var CervezaArtesanal = Negocio.productos.Find(i => i.ID == 10);

            var Venta = new Venta
            {
                Caja = 1,
                Turno = 0,
                id = 1,
                activa = 1,
                Fecha = DateTime.Today,
                Cliente = new Cliente()

            };

            var resultadoEsperado = false;

            //Act

            var resultadoReal = Venta.AgregarProducto(CervezaArtesanal);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoReal);

        }

        [TestMethod]
        public void TestQuePruebaLaAutenticacionDeUnUsuarioInexistenteDevuelveFalso()
        {
            //Arrange
            Negocio.addUsuarios();
            Usuario userInexistente = new Usuario
            {
                Id = 12,
                Admin = true,
                User = "pepe",
                Passw = "1234"
            };
            var ResultadoEsperado = false;

            //Act

            var ResultadoReal = Negocio.Loguearse(userInexistente.User, userInexistente.Passw);

            //Assert
            Assert.AreEqual(ResultadoEsperado, ResultadoReal);
        }

        [TestMethod]
        public void TestQuePruebaElTotalDeUnProductoConAgregadosAdicionalesQuesoRetorna30()
        {
            //Arrange
            Negocio.agregarProductos();
            var Milanesa = Negocio.productos.Find(i => i.ID == 2);
            Milanesa.Agregados.Add(Negocio.productos.Find(i => i.ID == 8));

            var VentaMilanesaConQueso = new Venta
            {
                Caja = 1,
                Turno = 0,
                id = 1,
                activa = 1,
                Fecha = DateTime.Today,
                Cliente = new Cliente()

            };

            VentaMilanesaConQueso.AgregarProducto(Milanesa);


            var resultadoEsperado = 30;

            //Act
            var resultadoReal = VentaMilanesaConQueso.calcularTotal();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoReal);
        }

        [TestMethod]
        public void TestQuePruebaCierreDeCajaTurnoMananaDeTresVentasDaResultado()
        {
            //Arrange
            Negocio.agregarProductos();
            var Milanesa = Negocio.productos.Find(i => i.ID == 2);
            

            var VentaMilanesa1 = new Venta
            {
                Caja = 1,
                Turno = 0,
                id = 1,
                activa = 1,
                Fecha = DateTime.Today,
                Cliente = new Cliente()

            };

            VentaMilanesa1.AgregarProducto(Milanesa);
            VentaMilanesa1.activa = 0;
            

            var VentaMilanesa2 = new Venta
            {
                Caja = 1,
                Turno = 0,
                id = 1,
                activa = 1,
                Fecha = DateTime.Today,
                Cliente = new Cliente()

            };

            VentaMilanesa2.AgregarProducto(Milanesa);
            VentaMilanesa2.activa = 0;

            var VentaMilanesa3 = new Venta
            {
                Caja = 1,
                Turno = 0,
                id = 1,
                activa = 1,
                Fecha = DateTime.Today,
                Cliente = new Cliente()

            };

            VentaMilanesa3.AgregarProducto(Milanesa);
            VentaMilanesa3.activa = 0;


            Negocio.caja.ventas.Add(VentaMilanesa1);
            Negocio.caja.ventas.Add(VentaMilanesa2);
            Negocio.caja.ventas.Add(VentaMilanesa3);



            var resultadoEsperado = 75;

            //Act
            var resultadoReal = Negocio.TotalRecaudadoMan();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoReal);
        }
    }
}
