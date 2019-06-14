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
    public partial class FBuscarInsumo : Form
    {
        public FBuscarInsumo()
        {
            InitializeComponent();

            String _query = String.Format("SELECT NombreInsumo FROM insumo", cbxInsumo.Text);
            MySqlCommand _comando = new MySqlCommand(_query, BDcomun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            cbxInsumo.Items.Clear();
            if (_reader.HasRows)
                while (_reader.Read())
                    cbxInsumo.Items.Add(_reader.GetString("NombreInsumo"));
        }

        public insumo insumoSeleccionado { get; set; }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (dgvBuscar.SelectedRows.Count == 1)
            {
                int CodInsumo = Convert.ToInt32(dgvBuscar.CurrentRow.Cells[0].Value);
                insumoSeleccionado = InsumosDAL.ObtenerInsumo(CodInsumo);

                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvBuscar.DataSource = InsumosDAL.Buscar(cbxInsumo.Text);
        }
    }
}
