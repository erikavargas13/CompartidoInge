using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


namespace PROYECTO_FINAL
{

    public partial class ADMINISTRAR_SUCURSAL : Form
    {
        GMapMarker marker;
        GMapOverlay markerOverlay;
        DataTable dt;
        int filaSelecionada = 0;
        double LatInicial = -16.526581;
        double LngInicial = -68.104388;
        public ADMINISTRAR_SUCURSAL()
        {
            InitializeComponent();
        }

        private void ADMINISTRAR_SUCURSAL_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descrpcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Long", typeof(double)));

            //Insertar datos para mostrar en lista


            // Desactivar lat y long de la tabla 


            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 10;
            gMapControl1.AutoScroll = true;

            //Marker

            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red_dot);
            markerOverlay.Markers.Add(marker);//agregar al mapa

            //tooltip de texto 
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud: {1}", LatInicial, LngInicial);
            //agregar marcador 
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            // se obtiene lat y lng del mapa donde se apreto 
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            // se posicionan  en el txt de la latitud y longitud 

            txtLatitud.Text = lat.ToString();
            txtLongitud.Text = lng.ToString();
            // crear el marcador para moverlo al lugar indicado 

            marker.Position = new PointLatLng(lat, lng);

            // agregar el mensaje al tooltip

            marker.ToolTipText = string.Format("Ubicacion: \n Latitud: {0} \n Longitud: {1}", lat, lng);
            // CrearDireccionTrazarRuta(lat, lng); 
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            string latitud = txtLatitud.Text;
            string longitud = txtLongitud.Text;

            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("http://maps.google.com/maps?q=");
                if (latitud != String.Empty)
                {
                    query.Append(latitud + "," + "+");
                }
                if (longitud != String.Empty)
                {
                    query.Append(longitud);
                }

                webBrowser1.Navigate(query.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtLatitud.Text) || string.IsNullOrWhiteSpace(txtLongitud.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtTelefono.Text))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                sucursal psucursal = new sucursal();
                psucursal.CodSucursal = txtCodigo.Text.Trim();
                psucursal.NombreSucursal = txtNombre.Text.Trim();
                psucursal.TelefonoSucursal = Convert.ToInt32(txtTelefono.Text.Trim());
                psucursal.Latitud = Convert.ToDouble(txtLatitud.Text);
                psucursal.Longitud = Convert.ToDouble(txtLongitud.Text);
                psucursal.DireccionSucural = txtDireccion.Text.Trim();

                int resultado = BDconsultas.AgregarSucursal(psucursal);
                if (resultado > 0)
                {
                    MessageBox.Show("Sucursal Guardada Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    // Deshabilitar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la sucursal", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
        void Limpiar()
        {
            txtCodigo.Clear();
            txtDireccion.Clear();
            txtLatitud.Clear();
            txtLongitud.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private void trackZoom_ValueChanged(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackZoom.Value;
        }

        private void bt_satelital_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
        }

        private void bt_normal_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
        }

        private void bt_relieve_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            MENU_SUCURSAL mensuc = new MENU_SUCURSAL();
            mensuc.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackZoom.Value = Convert.ToInt32(gMapControl1.Zoom);
        }

        public sucursal sucursalactual { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            MENU_BORRARSUCURSAL buscar = new MENU_BORRARSUCURSAL();
            buscar.ShowDialog();

            if (buscar.SucursalSeleccionada != null)

            {
                sucursalactual = buscar.SucursalSeleccionada;
                txtCodigo.Text = buscar.SucursalSeleccionada.CodSucursal;
                txtDireccion.Text = buscar.SucursalSeleccionada.DireccionSucural;
                txtLatitud.Text = Convert.ToString(buscar.SucursalSeleccionada.Latitud);
                txtLongitud.Text = Convert.ToString(buscar.SucursalSeleccionada.Longitud);
                txtNombre.Text = buscar.SucursalSeleccionada.NombreSucursal;
                txtTelefono.Text = Convert.ToString(buscar.SucursalSeleccionada.TelefonoSucursal);

                bt_actualizar.Enabled = true;
                bt_eliminar.Enabled = true;
                Habilitar();
                bt_guardar.Enabled = false;
            }
        }
        void Habilitar()
        {
            txtCodigo.Enabled = true;
            txtDireccion.Enabled = true;
            txtLatitud.Enabled = true;
            txtLongitud.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            bt_guardar.Enabled = true;

        }

        private void bt_actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtLatitud.Text) || string.IsNullOrWhiteSpace(txtLongitud.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
           string.IsNullOrWhiteSpace(txtTelefono.Text))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                sucursal psucursal = new sucursal();
                psucursal.CodSucursal = txtCodigo.Text.Trim();
                psucursal.NombreSucursal = txtNombre.Text.Trim();
                psucursal.TelefonoSucursal = Convert.ToInt32(txtTelefono.Text.Trim());
                psucursal.Latitud = Convert.ToDouble(txtLatitud.Text);
                psucursal.Longitud = Convert.ToDouble(txtLongitud.Text);
                psucursal.DireccionSucural = txtDireccion.Text.Trim();

                int resultado = BDconsultas.ActualizarSucursal(psucursal);
                if (resultado > 0)
                {
                    MessageBox.Show("Sucursal Actualizada Con Exito!!", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                   
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la sucursal", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        private void bt_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar la sucursal Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (BDconsultas.EliminarSucursal(sucursalactual.CodSucursal) > 0)

                {
                    MessageBox.Show("Sucursal Eliminada Correctamente!", "Sucursal Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }

                else

                {
                    MessageBox.Show("No se pudo eliminar la sucursal", "Sucursal No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else

                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }

}
