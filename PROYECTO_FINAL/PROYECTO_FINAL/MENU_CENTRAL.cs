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
    public partial class MENU_CENTRAL : Form
    {
        public MENU_CENTRAL()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ControlDeMerma inicio = new ControlDeMerma();
            inicio.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MENU_SUCURSAL sucu = new MENU_SUCURSAL();
            sucu.Show();
            this.Hide();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MENU_ASIGNACION asig = new MENU_ASIGNACION();
            asig.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MENU_PERSONAL mpersonal = new MENU_PERSONAL();
            mpersonal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MENU_PRODUCTOS mproduc = new MENU_PRODUCTOS();
            mproduc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MENU_MERMAS mmermas = new MENU_MERMAS();
            mmermas.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
