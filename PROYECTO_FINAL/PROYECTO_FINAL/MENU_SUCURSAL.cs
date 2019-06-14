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
    public partial class MENU_SUCURSAL : Form
    {
        public MENU_SUCURSAL()
        {
            InitializeComponent();
        }

        private void bt_registrar_Click(object sender, EventArgs e)
        {
            ADMINISTRAR_SUCURSAL admisuc = new ADMINISTRAR_SUCURSAL();
            admisuc.Show();
            this.Hide();
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            MENU_BORRARSUCURSAL buscarsuc = new MENU_BORRARSUCURSAL();
            buscarsuc.Show();
            this.Hide();
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            MENU_CENTRAL central = new MENU_CENTRAL();
            central.Show();
            this.Hide();
        }
    }
}
