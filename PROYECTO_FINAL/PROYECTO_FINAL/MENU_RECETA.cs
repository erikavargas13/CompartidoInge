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
    public partial class MENU_RECETA : Form
    {
        public MENU_RECETA()
        {
            InitializeComponent();
        }

        private void e_Click(object sender, EventArgs e)
        {
            MENU_CENTRAL mcentral = new MENU_CENTRAL();
            mcentral.Show();
            this.Hide();
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {

        }
    }
}
