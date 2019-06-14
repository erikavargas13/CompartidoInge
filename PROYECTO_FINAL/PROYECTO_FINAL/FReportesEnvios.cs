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
    public partial class FReportesEnvios : Form
    {
        public FReportesEnvios()
        {
            InitializeComponent();
            label2.Visible = false;
            FechaBusqueda.Visible = false;

            label3.Visible = false;
            cbxSucursal.Visible = false;
        }
        public void LlenarDatosEnvios(DataGridView dvg)
        {
            try
            {
                FechaBusqueda.Format = DateTimePickerFormat.Custom;
                FechaBusqueda.CustomFormat = "yyyy/MM/dd";
                String fecha1 = FechaBusqueda.Value.Date.ToString("yyyy/MM/dd");

                MySqlCommand comando = new MySqlCommand(String.Format("SELECT CodOrigen, CodDestino, CodProducto, CantidadEnvio, FechaHora FROM envio WHERE FechaHora = '{0}'", fecha1), BDcomun.ObtenerConexion());
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dvg.DataSource = dt;

            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }


        public void LlenarDatosEnviosSucursales(DataGridView grid)
        {
            try
            {
                MySqlCommand comando1 = new MySqlCommand(String.Format("SELECT CodOrigen, CodProducto, CantidadEnvio, FechaHora FROM envio WHERE CodDestino = '{0}'", cbxSucursal.SelectedItem), BDcomun.ObtenerConexion());
                MySqlDataAdapter ds = new MySqlDataAdapter(comando1);
                DataTable dr = new DataTable();
                ds.Fill(dr);
                grid.DataSource = dr;
            }

            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(cbxSucursal.Visible == true)
            {
                LlenarDatosEnviosSucursales(dgvEnvios);
                dgvEnvios.Update();
            }

            else

            LlenarDatosEnvios(dgvEnvios);
            dgvEnvios.Update();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            cbxSucursal.Visible = false;
            label2.Visible = true;
            FechaBusqueda.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            FechaBusqueda.Visible = false;
            label3.Visible = true;
            cbxSucursal.Visible = true;

            String query = String.Format("SELECT CodSucursal FROM sucursal", cbxSucursal.Text);
            MySqlCommand comando = new MySqlCommand(query, BDcomun.ObtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            cbxSucursal.Items.Clear();
            if (reader.HasRows)
                while (reader.Read())
                    cbxSucursal.Items.Add(reader.GetString("CodSucursal"));


        }
    }
}
