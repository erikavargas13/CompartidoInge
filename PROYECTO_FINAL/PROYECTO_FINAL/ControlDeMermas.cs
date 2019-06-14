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
    public partial class ControlDeMermas : Form
    {
        public ControlDeMermas()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataGridView1.CurrentCell = null;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(textBox1.Text.ToUpper()) == 0)
                        {
                            r.Visible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                dataGridView1.DataSource = BDconsultas.ListarMermas();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlParameter param;
            MySqlParameter param2;
            param = new MySqlParameter("@p1", MySqlDbType.DateTime);
            param2 = new MySqlParameter("@p2", MySqlDbType.DateTime);
            param.Value = dateTimePicker1.Value;
            param2.Value = dateTimePicker2.Value;
            dataGridView1.DataSource = BDconsultas.ListarMermasporFecha(param, param2);
        }

        private void ControlDeMermas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BDconsultas.ListarMermas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MENU_CENTRAL mcentral = new MENU_CENTRAL();
            mcentral.Show();
            this.Hide();
        }
    }
}
