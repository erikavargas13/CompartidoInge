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
    public partial class ControlDeMerma : Form
    {
        public ControlDeMerma()
        {
            InitializeComponent();
        }

        public roles RolSelecionado { get; set; }
        private void bt_verificar_Click(object sender, EventArgs e)
        {
            try
            {
                bool verificar = false;
                persona pers = new persona (tb_usuario.Text, tb_pass.Text);
                verificar = BDconsultas.LogInAdmi(pers.CodigoPersona, pers.PassPersona);
                if (verificar == true)
                {
                    RolSelecionado = BDconsultas.ObtenerCodigo(tb_usuario.Text);
                    
                   

                     if(RolSelecionado != null)
                      {
                        string rolselec = RolSelecionado.CodRoles;
                        if(rolselec == "01")
                        {
                            MessageBox.Show("BIENVENIDO DE NUEVO ", "ADMINISTRADOR DE CENTRAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MENU_CENTRAL menu_central = new MENU_CENTRAL();
                            menu_central.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("BIENVENIDO DE NUEVO ", "ADMINISTRADOR DE SUCURSAL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                      

                }
                else
                {
                    MessageBox.Show("CÓDIGO O CONTRASEÑA INCORRECTA", "ERROR AL VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {
                MessageBox.Show("VUELVA A INTENTARLO", "ERROR CON LA BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ControlDeMerma_Load(object sender, EventArgs e)
        {

        }
    }
}
