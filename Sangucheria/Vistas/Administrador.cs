using Sangucheria.Modelo;
using Sangucheria.Presentador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sangucheria.Vistas
{
    public partial class Administrador : Form, IAdministrador
    {
        

        AdministradorPresentador presentador;
        public Administrador()
        {
            InitializeComponent();
            presentador = new AdministradorPresentador(this);
        }

        public string TotalManana { get => label3.Text; set => label3.Text = value; }
        public string TotalTarde { get => label4.Text; set => label4.Text = value; }

        private void Administrador_Load(object sender, EventArgs e)
        {
            
        }

       

        
        private void button4_Click(object sender, EventArgs e)
        {
            presentador.TotalRecaudado();
        }


     
    }
}
