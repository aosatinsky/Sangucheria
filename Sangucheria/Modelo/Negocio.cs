using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangucheria.Modelo
{
    public static class Negocio
    {
        public static List<Producto> productos = new List<Producto>();
        public static List<Cliente> clientes = new List<Cliente>();
        public static List<Usuario> usuarios = new List<Usuario>();

        public static EnumCondicionTributaria CondicionTributaria = EnumCondicionTributaria.MONOTRIBUTISTA;
        public static TPDV caja = new TPDV();
        public static string contrasenia = "root";
        
        public static List<Cliente> GetClientes()
        {

            return clientes;
        }

        public static bool Loguearse(string user, string passw)
        {
            try
            {
                if (usuarios.Where(u => u.User == user && u.Passw == passw).First() != null)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

        public static void addUsuarios()
        {
            usuarios.Add(new Usuario
            {
                Id = 1,
                User = "agustin",
                Passw = "1234",
                Admin = true
            });

            usuarios.Add(new Usuario
            {
                Id = 2,
                User = "gino",
                Passw = "1234",
                Admin = false
            });
        }

        public static void addClientes()
        {
            clientes.Add(new Cliente
            {
                CondicionTributaria = EnumCondicionTributaria.CONSUMIDOR_FINAL,
                TipoDoc = EnumTipoDoc.DNI,
                Doc = 12345678
            });

            clientes.Add(new Cliente
            {
                CondicionTributaria = EnumCondicionTributaria.CONSUMIDOR_FINAL,
                TipoDoc = EnumTipoDoc.DNI,
                Doc = 87654321
            });

            clientes.Add(new Cliente
            {
                CondicionTributaria = EnumCondicionTributaria.CONSUMIDOR_FINAL,
                TipoDoc = EnumTipoDoc.DNI,
                Doc = 12873456
            });
        }

        public static List<Producto> GetProductos()
        {
            return productos;
        }

        public static void addProducto(Producto pro)
        {
            productos.Add(pro);
        }

        public static void agregarProductos()
        {
            productos.Add(new Producto()
            {
                ID = 1,
                Nombre = "CocaCola",
                Rubro = enumRubros.Bebida,
                Precio = 10,
                Existencia = 50
            });
            productos.Add(new Producto()
            {
                ID = 2,
                Nombre = "Milanesa",
                Rubro = enumRubros.Sanguche,
                Precio = 25,
                Existencia = 50,
                Agregados = new List<Producto> { new Producto()
            {
                ID = 6,
                Nombre = "Lechuga",
                Rubro = enumRubros.Agregado,
                Precio = 0,
                Existencia = 100000
            },
               new Producto()
            {
                ID = 7,
                Nombre = "Tomate",
                Rubro = enumRubros.Agregado,
                Precio = 0,
                Existencia = 100000
            } }
            });
            productos.Add(new Producto()
            {
                ID = 3,
                Nombre = "Quilmes",
                Rubro = enumRubros.Alcohol,
                Precio = 15,
                Existencia = 50
            });
            productos.Add(new Producto()
            {
                ID = 4,
                Nombre = "Papas",
                Rubro = enumRubros.Entrante,
                Precio = 15,
                Existencia = 50
            });
            productos.Add(new Producto()
            {
                ID = 5,
                Nombre = "Napolitana al plato",
                Rubro = enumRubros.Plato,
                Precio = 20,
                Existencia = 50
            });
            productos.Add(new Producto()
            {
                ID = 6,
                Nombre = "Lechuga",
                Rubro = enumRubros.Agregado,
                Precio = 0,
                Existencia = 100000
            });
            productos.Add(new Producto()
            {
                ID = 7,
                Nombre = "Tomate",
                Rubro = enumRubros.Agregado,
                Precio = 0,
                Existencia = 100000
            });
            productos.Add(new Producto()
            {
                ID = 8,
                Nombre = "Queso",
                Rubro = enumRubros.Agregado,
                Precio = 5,
                Existencia = 1000000
            });
            productos.Add(new Producto()
            {
                ID = 9,
                Nombre = "Huevo",
                Rubro = enumRubros.Agregado,
                Precio = 5,
                Existencia = 1000000
            });
            productos.Add(new Producto()
            {
                ID = 10,
                Nombre = "Cerveza Artesanal",
                Rubro = enumRubros.Alcohol,
                Precio = 60,
                Existencia = 0
            });
        }

        public static double TotalRecaudadoMan()
        {
            double total = 0;
            foreach (var item in caja.GetVentas().Where(u => u.Turno == 0))
            {
                total += item.calcularTotal();

            }
            return total;
        }

    }
}
