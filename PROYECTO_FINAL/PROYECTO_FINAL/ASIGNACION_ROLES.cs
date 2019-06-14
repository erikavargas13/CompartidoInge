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
    public partial class ASIG_ROL : Form
    {
        public ASIG_ROL()
        {
            InitializeComponent();
            String _query = String.Format("SELECT CodigoPersona FROM persona", comboBox1.Text);
            MySqlCommand _comando = new MySqlCommand(_query, BDcomun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            comboBox1.Items.Clear();
            if (_reader.HasRows)
                while (_reader.Read())
                    comboBox1.Items.Add(_reader.GetString("CodigoPersona"));

            String _query2 = String.Format("SELECT CodRoles FROM roles", comboBox2.Text);
            MySqlCommand _comando2 = new MySqlCommand(_query2, BDcomun.ObtenerConexion());
            MySqlDataReader _reader2 = _comando2.ExecuteReader();
            comboBox2.Items.Clear();
            if (_reader2.HasRows)
                while (_reader2.Read())
                    comboBox2.Items.Add(_reader2.GetString("CodRoles"));

            dataGridView1.DataSource = BDconsultas.BuscarAsignaciones();
        }

     

        private void button4_Click(object sender, EventArgs e)
        {
            MENU_PERSONAL mperso = new MENU_PERSONAL();
            mperso.Show();
            this.Hide();
        }

        
        private void bt_registrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox2.Text) )

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                asig_rol proles = new asig_rol();
                proles.CodPersona = comboBox1.Text;
                proles.CodRol = comboBox2.Text;
               

                int resultado = BDconsultas.AgregarAsignacion(proles);
                if (resultado > 0)
                {
                    MessageBox.Show("Asignación Guardada Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la asignación", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bt_actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox2.Text))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                asig_rol proles = new asig_rol();
                proles.CodPersona = comboBox1.Text;
                proles.CodRol = comboBox2.Text;


                int resultado = BDconsultas.ActualizarAignaciones(proles);
                if (resultado > 0)
                {
                    MessageBox.Show("Asignación Actualizada Con Exito!!", "ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la asignación", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        public asig_rol asignacionactual { get; set; }
        private void bt_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar la asignación Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (BDconsultas.EliminarAsignacion(asignacionactual.CodRol) > 0)

                {
                    MessageBox.Show("Asignación Eliminada Correctamente!", "Asignación Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else

                {
                    MessageBox.Show("No se pudo eliminar la asignación", "Asignación No Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else

                MessageBox.Show("Se cancelo la asignación", "Asignación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BDconsultas.BuscarAsignaciones();
        }

        private void bt_selec_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string id = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                asignacionactual = BDconsultas.ObtenerAsignacion(id);


            }
            else
                MessageBox.Show("Debe de seleccionar una fila");
            if (asignacionactual != null)
            {
                
                comboBox1.Text = Convert.ToString(asignacionactual.CodPersona);
                comboBox2.Text = Convert.ToString(asignacionactual.CodRol);
                

            }
        }
    }
}
