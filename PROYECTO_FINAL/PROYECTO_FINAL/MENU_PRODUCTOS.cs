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
    public partial class MENU_PRODUCTOS : Form
    {
        public MENU_PRODUCTOS()
        {
            InitializeComponent();
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            MENU_CENTRAL mcentral = new MENU_CENTRAL();
            mcentral.Show();
            this.Close();
        }

        private void bt_registrar_Click(object sender, EventArgs e)
        {
            FPRODUCTOS productos = new FPRODUCTOS();
            productos.ShowDialog();
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            FINSUMOS insumos = new FINSUMOS();
            insumos.ShowDialog();
        }

        private void MENU_PRODUCTOS_Load(object sender, EventArgs e)
        {

        }
    }
}
