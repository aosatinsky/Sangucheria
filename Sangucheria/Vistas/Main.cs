using Sangucheria.Adaptadores;
using Sangucheria.Modelo;
using Sangucheria.Presentador;
using Sangucheria.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sangucheria
{
    public partial class Form1 : Form, IMain
    {
        public int caja { get => int.Parse(comboBox1.SelectedItem.ToString()); set => throw new NotImplementedException(); }
        public string passw { get => textBox3.Text; set => throw new NotImplementedException(); }
        public int turno { get
            {
                if (radioMan.Checked == true)
                {
                    return 0;
                }
                else
                    return 1;

            }
            set => throw new NotImplementedException();
        }

        
        public string user { get => textBox1.Text; set => throw new NotImplementedException(); }

        MainPresentador presentador;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Negocio.agregarProductos();
            Negocio.addClientes();
            Negocio.addUsuarios();
            presentador = new MainPresentador(this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            presentador.AbrirPedidos();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            presentador.AbrirAdministrador();
        }
    }
}
