using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_Agenda
{
    public partial class Principal : Form
    {
        private int id;
        agenda age = new agenda();
        DataTable dt;

        public Principal()
        {
            InitializeComponent();
            restablecerControles();
            consultar();
            dgvAgenda.Columns["id"].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void consultar()
        {
            dgvAgenda.DataSource = dt = age.consultar(id);
        }

        private void obtenerId()
        {
            id = Convert.ToInt32(dgvAgenda.CurrentRow.Cells["id"].Value);
        }
        private void obtenerDatos()
        {
            obtenerId();
            txtNombre.Text = dgvAgenda.CurrentRow.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = dgvAgenda.CurrentRow.Cells["Teléfono"].Value.ToString();
        }
        private void restablecerControles()
        {
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtFiltrar.Clear();
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = false;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool rs = age.insertar(txtNombre.Text, txtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Inserción satisfactoria");
            }
            restablecerControles();
            consultar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool rs = age.actualizar(id, txtNombre.Text, txtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Actualizado Success");
                consultar();
            }
            restablecerControles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r =
                MessageBox.Show("Eliminar",
                "¿Está seguro?",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);

            if (r == DialogResult.OK)
            {
                bool rs = age.eliminar(id);
                if (rs)
                {
                    MessageBox.Show("Eliminación satisfactoria");
                    consultar();
                }
                restablecerControles();

            }
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"Nombre LIKE '%{txtFiltrar.Text}";
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            restablecerControles();
            obtenerId();
            this.btnEliminar.Enabled = true;
        }

        private void dgvAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerDatos();
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = false;
        }
    }
}
