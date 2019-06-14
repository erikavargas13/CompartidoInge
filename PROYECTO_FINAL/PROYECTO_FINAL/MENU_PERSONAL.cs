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
    public partial class MENU_PERSONAL : Form
    {
        public MENU_PERSONAL()
        {
            InitializeComponent();
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            MENU_CENTRAL central = new MENU_CENTRAL();
            central.Show();
            this.Hide();
        }

        private void bt_asig_Click(object sender, EventArgs e)
        {
            ASIG_ROL rol = new ASIG_ROL();
            rol.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            REGISTRO_PERSONAL perso = new REGISTRO_PERSONAL();
            perso.Show();
            this.Hide();
        }
    }
}
