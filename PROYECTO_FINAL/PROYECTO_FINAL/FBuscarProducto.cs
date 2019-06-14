using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PROYECTO_FINAL
{
    public partial class FBuscarProducto : Form
    {
        public FBuscarProducto()
        {
            InitializeComponent();

            String _query = String.Format("SELECT NombreProducto FROM producto", cbxProducto.Text);
            MySqlCommand _comando = new MySqlCommand(_query, BDcomun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            cbxProducto.Items.Clear();
            if (_reader.HasRows)
                while (_reader.Read())
                    cbxProducto.Items.Add(_reader.GetString("NombreProducto"));

        }

        public producto productoSeleccionado { get; set; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvBuscarProducto.DataSource = ProductosDAL.Buscar(cbxProducto.Text);
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBuscar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvBuscarProducto.SelectedRows.Count == 1)
            {
                int CodProducto = Convert.ToInt32(dgvBuscarProducto.CurrentRow.Cells[0].Value);
                productoSeleccionado = ProductosDAL.Obtenerproducto(CodProducto);

                this.Close();
            }

            else
                MessageBox.Show("debe seleccionar una fila");
        }
    }
}
