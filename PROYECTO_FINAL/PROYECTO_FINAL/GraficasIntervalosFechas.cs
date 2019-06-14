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
    public partial class GraficasIntervalosFechas : Form
    {
        public GraficasIntervalosFechas()
        {
            InitializeComponent();
        }

        private void GraficasIntervalosFechas_Load(object sender, EventArgs e)
        {


            chart1.Visible = false;
            chart2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)//buscar y llenar el Datagrid
        {

            LlenarDatos(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)//Mostrar graficas
        {
            chart1.Series["TotalMermas"].Points.Clear();
            chart1.Titles.Clear();
            chart2.Series["CantidadTotalMermas"].Points.Clear();
            chart2.Titles.Clear();

            chart1.Visible = true;
            chart2.Visible = true;
            dataGridView1.Update();
            if (dataGridView1.Rows.Count != 0)
            {
                chart1.Titles.Add("CANTIDAD TOTAL DE MERMAS POR SUCURSAL");
                chart2.Titles.Add("CANTIDAD TOTAL DE MERMAS POR SUCURSAL");

                int filas = dataGridView1.Rows.Count;

                for (int i = 0; i <= filas - 2; i++)
                {

                    chart1.Series["TotalMermas"].Points.AddXY(dataGridView1[0, i].Value.ToString(), dataGridView1[1, i].Value.ToString());
                    chart2.Series["CantidadTotalMermas"].Points.AddXY(dataGridView1[0, i].Value.ToString(), dataGridView1[1, i].Value.ToString());
                }

            }

            else
                MessageBox.Show(" NO HAY REGISTRO DE MERMAS PARA GRAFICAR");
        }
        public void LlenarDatos(DataGridView dvg)
        {

            FechaInicial.Format = DateTimePickerFormat.Custom;
            FechaInicial.CustomFormat = "yyyy/MM/dd";
            String fechainicial = FechaInicial.Value.Date.ToString("yyyy/MM/dd");


            fechaFinal.Format = DateTimePickerFormat.Custom;
            fechaFinal.CustomFormat = "yyyy/MM/dd";
            String fechafinal = fechaFinal.Value.Date.ToString("yyyy/MM/dd");

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT s.NombreSucursal,SUM(m.CantidadMerma)AS TOTAL  FROM merma m INNER JOIN sucursal s ON m.CodSucursal= s.CodSucursal INNER JOIN producto p ON m.CodProducto = p.CodProducto WHERE m.FechaHora BETWEEN '{0}' AND '{1}' GROUP BY m.CodSucursal", fechainicial, fechafinal), BDcomun.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dvg.DataSource = dt;


        }

    }
}
