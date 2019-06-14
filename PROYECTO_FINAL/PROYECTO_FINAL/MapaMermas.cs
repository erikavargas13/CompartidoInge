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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms.DataVisualization.Charting;

namespace PROYECTO_FINAL
{
    public partial class MapaMermas : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;
        double LatInicial = -16.384156;
        double LngInicial = -68.147251;

        private int CantidaTotalMermas;

        public MapaMermas()
        {
            InitializeComponent();
        }

        private void MapaMermas_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;
            chart1.Visible = false;
            chart2.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e) //Boton para desplegar el registro de mermas 
        {
            gMapControl1.Overlays.Remove(markerOverlay);
            LlenarDatosMermas(dataGridView1);
            gMapControl1.Visible = true;
            chart1.Visible = false;
            chart2.Visible = false;

            dataGridView1.Update();
        }

        private void button2_Click(object sender, EventArgs e) //Boton para Mostrar las Graficas
        {
            chart1.Series["CantidadMermas"].Points.Clear();
            chart1.Titles.Clear();
            chart2.Series["CantidadMermas"].Points.Clear();
            chart2.Titles.Clear();
            gMapControl1.Visible = false;
            chart1.Visible = true;
            chart2.Visible = true;
            dataGridView1.Update();
            if (dataGridView1.Rows.Count != 0)
            {
                chart1.Titles.Add("CANTIDAD DE MERMAS POR SUCURSAL");
                chart2.Titles.Add("CANTIDAD DE MERMAS POR SUCURSAL");
                int filas = dataGridView1.Rows.Count;

                for (int i = 0; i <= filas - 2; i++)
                {

                    chart1.Series["CantidadMermas"].Points.AddXY(dataGridView1[1, i].Value.ToString(), dataGridView1[5, i].Value.ToString());
                    chart2.Series["CantidadMermas"].Points.AddXY(dataGridView1[1, i].Value.ToString(), dataGridView1[5, i].Value.ToString());
                }

            }

            else
                MessageBox.Show(" NO HAY REGISTRO DE MERMAS PARA GRAFICAR");
        }

        private void button3_Click(object sender, EventArgs e) // Boton para ir al form con graficas de reportes en un intervalo de fechas
        {
            GraficasIntervalosFechas gf = new GraficasIntervalosFechas();
            gf.Show();
        }
        public void LlenarDatosMermas(DataGridView dvg)
        {
            try
            {
                FechaBusqueda.Format = DateTimePickerFormat.Custom;
                FechaBusqueda.CustomFormat = "yyyy/MM/dd";
                String fecha1 = FechaBusqueda.Value.Date.ToString("yyyy/MM/dd");

                MySqlCommand comando = new MySqlCommand(String.Format("SELECT s.CodSucursal,s.NombreSucursal,s.Latitud,s.Longitud,p.NombreProducto,m.CantidadMerma,m.FechaHora FROM merma m INNER JOIN sucursal s ON m.CodSucursal= s.CodSucursal INNER JOIN producto p ON m.CodProducto = p.CodProducto WHERE m.FechaHora = '{0}'", fecha1), BDcomun.ObtenerConexion());
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dvg.DataSource = dt;

                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[6].Visible = false;

                int suma = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[5].Value != null)
                        suma += (Int32)row.Cells[5].Value;
                }
                CantidaTotalMermas = suma;


                textBox1.Text = CantidaTotalMermas.ToString();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void Seleccionar_Registro(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {


                    string CodSucursal = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string NombreSucursal = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    string NombreProducto = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    string CantidadMerma = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    LatInicial = Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value);
                    LngInicial = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value);
                    markerOverlay = new GMapOverlay("Marcador");
                    marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red);
                    markerOverlay.Markers.Add(marker);
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = String.Format("SUCURSAL:{0} \n PRODUCTO:{1} \n CANTIDAD:{2} ", NombreSucursal, NombreProducto, CantidadMerma);
                    gMapControl1.Overlays.Add(markerOverlay);

                }
                else
                    MessageBox.Show("Debe de seleccionar una fila");
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
