using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sangucheria.Modelo;
using Sangucheria.Presentador;

namespace Sangucheria.Vistas
{
    public partial class Agregados : Form, IAgregados
    {
        AgregadosPresentador presentador;
        public Producto prod { get; set; }
        public Agregados(Producto producto)
        {
            InitializeComponent();
            presentador = new AgregadosPresentador(this);
            prod = producto;
        }

        public List<Producto> NuevoAgregado { get => (List<Producto>)productoBindingSource.DataSource; set => productoBindingSource.DataSource = value; }
        public Producto Producto { get => (Producto)dataGridView1.CurrentRow.DataBoundItem; set => throw new NotImplementedException(); }
        public Producto Agregar { get => (Producto)dataGridView2.CurrentRow.DataBoundItem; set => throw new NotImplementedException(); }
        List<Producto> IAgregados.Agregados { get => (List<Producto>)productoBindingSource1.DataSource; set => productoBindingSource1.DataSource = value; }

        private void Agregados_Load(object sender, EventArgs e)
        {
            productoBindingSource.DataSource = prod.Agregados;
            productoBindingSource.ResetBindings(false);
            presentador.CargarAgregados();
            productoBindingSource1.ResetBindings(false);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            presentador.Agregar(prod);
            productoBindingSource.ResetBindings(false);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                presentador.BorrarAgregado(prod);
            }
        }
    }
}
