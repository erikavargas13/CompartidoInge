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
    public partial class FINSUMOS : Form
    {
        public FINSUMOS()
        {
            InitializeComponent();
        }

        public insumo insumoActual { get; set; }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodInsumo.Text) || string.IsNullOrWhiteSpace(txtNombreInsumo.Text) || string.IsNullOrWhiteSpace(txtTipoInsumo.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                insumo pInsumo = new insumo();

                pInsumo.CodInsumo = txtCodInsumo.Text.Trim();
                pInsumo.NombreInsumo = txtNombreInsumo.Text.Trim();
                pInsumo.TipoInsumo = txtTipoInsumo.Text.Trim();
                pInsumo.CantidadInsumo = txtCantidad.Text.Trim();


                int resultado = InsumosDAL.AgregarInsumos(pInsumo);
                if (resultado > 0)
                {
                    MessageBox.Show("Insumo Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el insumo", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarInsumo buscar = new FBuscarInsumo();
            buscar.ShowDialog();

            if (buscar.insumoSeleccionado != null)

            {
                insumoActual = buscar.insumoSeleccionado;
                txtCodInsumo.Text = buscar.insumoSeleccionado.CodInsumo;
                txtNombreInsumo.Text = buscar.insumoSeleccionado.NombreInsumo;
                txtTipoInsumo.Text = buscar.insumoSeleccionado.TipoInsumo;
                txtCantidad.Text = buscar.insumoSeleccionado.CantidadInsumo;

                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                Habilitar();
                btnGuardar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodInsumo.Text) || string.IsNullOrWhiteSpace(txtNombreInsumo.Text) || string.IsNullOrWhiteSpace(txtTipoInsumo.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                insumo pInsumo = new insumo();

                pInsumo.CodInsumo = txtCodInsumo.Text.Trim();
                pInsumo.NombreInsumo = txtNombreInsumo.Text.Trim();
                pInsumo.TipoInsumo = txtTipoInsumo.Text.Trim();
                pInsumo.CantidadInsumo = txtCantidad.Text.Trim();

                pInsumo.CodInsumo = insumoActual.CodInsumo;

                if (InsumosDAL.Actualizar(pInsumo) > 0)
                {
                    MessageBox.Show("Los datos del Insumo se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Insumo Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (InsumosDAL.Eliminar(insumoActual.CodInsumo) > 0)

                {
                    MessageBox.Show("Insumo Eliminado Correctamente!", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Deshabilitar();
                }

                else

                {
                    MessageBox.Show("No se pudo eliminar el Insumo", "Insumo No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else

                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
        }

        private void FINSUMOS_Load(object sender, EventArgs e)
        {
            Deshabilitar();
        }

        void Limpiar()
        {
            txtCodInsumo.Clear();
            txtNombreInsumo.Clear();
            txtTipoInsumo.Clear();
            txtCantidad.Clear();
        }


        void Habilitar()
        {
            txtCodInsumo.Enabled = true;
            txtNombreInsumo.Enabled = true;
            txtTipoInsumo.Enabled = true;
            txtCantidad.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }


        void Deshabilitar()
        {
            txtCodInsumo.Enabled = false;
            txtNombreInsumo.Enabled = false;
            txtTipoInsumo.Enabled = false;
            txtCantidad.Enabled = false;

            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;

            btnNuevo.Enabled = true;
        }


    }
}
