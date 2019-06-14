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
    public partial class MENU_BORRARSUCURSAL : Form
    {
        public MENU_BORRARSUCURSAL()
        {
            InitializeComponent();
            String _query = String.Format("SELECT CodSucursal FROM sucursal", comboBox1.Text);
            MySqlCommand _comando = new MySqlCommand(_query, BDcomun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            comboBox1.Items.Clear();
            if (_reader.HasRows)
                while (_reader.Read())
                    comboBox1.Items.Add(_reader.GetString("CodSucursal"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BDconsultas.BuscarSucursal(comboBox1.Text);

        }

        private void bt_msucurales_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BDconsultas.BuscarSucursales();
        }

        private void bt_borrar_Click(object sender, EventArgs e)
        {

        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            MENU_SUCURSAL mensuc = new MENU_SUCURSAL();
            mensuc.Show();
            this.Hide();
        }

        public sucursal SucursalSeleccionada { get; set; }
        private void bt_seleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string codigosucursal = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                SucursalSeleccionada = BDconsultas.ObtenerSucursal(codigosucursal);

                this.Close();
            }
            else
                MessageBox.Show("Debe de seleccionar una fila");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
