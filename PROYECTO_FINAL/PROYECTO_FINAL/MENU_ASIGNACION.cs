using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_FINAL
{
    public partial class MENU_ASIGNACION : Form
    {
        public MENU_ASIGNACION()
        {
            InitializeComponent();
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            MENU_CENTRAL mcentral = new MENU_CENTRAL();
            mcentral.Show();
            this.Hide();
        }

        private void bt_asignar_Click(object sender, EventArgs e)
        {
            FAsignaciones asignaciones = new FAsignaciones();
            asignaciones.Show();
        }

        private void bt_reporte_Click(object sender, EventArgs e)
        {
            FReportesEnvios reportesenvios = new FReportesEnvios();
            reportesenvios.Show();
        }
    }
}
