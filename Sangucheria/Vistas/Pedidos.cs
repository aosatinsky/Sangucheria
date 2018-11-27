using Sangucheria.Modelo;
using Sangucheria.Presentador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sangucheria.Vistas
{
    public partial class Pedidos : Form, IPedidos
    {

        public List<LineaDeVenta> lineaDeVentas { get => (List<LineaDeVenta>) orderProductBindingSource.DataSource; set => orderProductBindingSource.DataSource = value; }
        public List<Producto> productos { get => (List<Producto>)productoBindingSource.DataSource; set => productoBindingSource.DataSource = value; }
        public Producto producto { get => (Producto)dataGridView2.CurrentRow.DataBoundItem; set => throw new NotImplementedException(); }
        public LineaDeVenta lineaDeVenta { get => (LineaDeVenta)dataGridView1.CurrentRow.DataBoundItem; set => throw new NotImplementedException(); }
        public string total { get =>total_txt.Text; set =>total_txt.Text = value; }
        public List<Cliente> clientes { get => (List<Cliente>)clienteBindingSource.DataSource; set => clienteBindingSource.DataSource = value; }
        public Cliente cliente { get => (Cliente)comboBox1.SelectedItem; set => throw new NotImplementedException(); }

        PedidosPresentador presentador;

        public Pedidos()
        {
            InitializeComponent();
            presentador = new PedidosPresentador(this);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            presentador.AgregarProducto();
            orderProductBindingSource.DataSource = presentador.GetVentaActiva();
            orderProductBindingSource.ResetBindings(false);

        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            productoBindingSource.DataSource = presentador.GetProductos();
            productoBindingSource.ResetBindings(false);
            clienteBindingSource.DataSource = presentador.CargarClientes();
            clienteBindingSource.ResetBindings(false);

            this.SizeChanged += new EventHandler(dataGridView2_SizeChanged);
            total_txt.TextChanged += new EventHandler(dataGridView2_SizeChanged);
            textBox1.TextChanged +=new EventHandler(dataGridView2_SizeChanged);
        }

        public void AgregarProducto(Producto producto)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            presentador.BorrarItem();
            orderProductBindingSource.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] resultados = presentador.RealizarPedido();

            MessageBox.Show("TOTAL: " + resultados[1] + " CAE: " + resultados[0]);
            orderProductBindingSource.DataSource = presentador.LineaVacia();
            orderProductBindingSource.ResetBindings(false);
            productoBindingSource.ResetBindings(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string nombrelow = textBox1.Text.ToLower();
            string nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nombrelow);
            List<Producto> prodaux = new List<Producto>();
            prodaux = (List<Producto>)productoBindingSource.DataSource;
            dataGridView2.DataSource = new BindingList<Producto>(prodaux.Where(pro => pro.Nombre.Contains(nombre) || pro.ID.ToString().Contains(textBox1.Text.ToString())).ToList());
            dataGridView2.Update();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            presentador.VerAgregados();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_SizeChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Height = (dataGridView2.ClientRectangle.Height - dataGridView2.ColumnHeadersHeight) / dataGridView2.Rows.Count;
            }

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].Width = -2;
            }

        }

        private void total_txt_TextChanged(object sender, EventArgs e)
        {
            orderProductBindingSource.ResetBindings(false);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
