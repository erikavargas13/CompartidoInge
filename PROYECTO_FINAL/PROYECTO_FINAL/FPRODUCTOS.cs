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
    public partial class FPRODUCTOS : Form
    {
        public FPRODUCTOS()
        {
            InitializeComponent();
        }

        public producto productoActual { get; set; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProducto.Text) || string.IsNullOrWhiteSpace(txtNombreProducto.Text) || string.IsNullOrWhiteSpace(txtTipoProducto.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                producto pProducto = new producto();

                pProducto.CodProducto = txtCodProducto.Text.Trim();
                pProducto.NombreProducto = txtNombreProducto.Text.Trim();
                pProducto.TipoProducto = txtTipoProducto.Text.Trim();
                pProducto.Cantidad = txtCantidad.Text.Trim(); 


                int resultado = ProductosDAL.AgregarProductos(pProducto) & ProductosDAL.AgregarDetalleStock(pProducto);
                if (resultado > 0)
                {
                    MessageBox.Show("Compra Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la compra", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarProducto buscarProducto = new FBuscarProducto();
            buscarProducto.ShowDialog();

            if (buscarProducto.productoSeleccionado != null)

            {
                productoActual = buscarProducto.productoSeleccionado;
                txtCodProducto.Text = buscarProducto.productoSeleccionado.CodProducto;
                txtNombreProducto.Text = buscarProducto.productoSeleccionado.NombreProducto;
                txtTipoProducto.Text = buscarProducto.productoSeleccionado.TipoProducto;
                txtCantidad.Text = buscarProducto.productoSeleccionado.Cantidad;

                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                Habilitar();
                btnGuardar.Enabled = false;
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProducto.Text) || string.IsNullOrWhiteSpace(txtNombreProducto.Text) || string.IsNullOrWhiteSpace(txtTipoProducto.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                producto pProducto = new producto();

                pProducto.CodProducto = txtCodProducto.Text.Trim();
                pProducto.NombreProducto = txtNombreProducto.Text.Trim();
                pProducto.TipoProducto = txtTipoProducto.Text.Trim();
                pProducto.Cantidad = txtCantidad.Text.Trim();

                pProducto.CodProducto = productoActual.CodProducto;

                if (ProductosDAL.Actualizar(pProducto) > 0)
                {
                    MessageBox.Show("Los datos del producto se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (MessageBox.Show("Esta Seguro que desea eliminar la compra Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (ProductosDAL.Eliminar(productoActual.CodProducto) > 0)

                {
                    MessageBox.Show("Producto Eliminado Correctamente!", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Deshabilitar();
                }

                else

                {
                    MessageBox.Show("No se pudo eliminar el producto", "Producto No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else

                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
        }

        private void FPRODUCTOS_Load(object sender, EventArgs e)
        {
            Deshabilitar();
        }


        void Limpiar()
        {
            txtCodProducto.Clear();
            txtNombreProducto.Clear();
            txtTipoProducto.Clear();
            txtCantidad.Clear();
        }


        void Habilitar()
        {
            txtCodProducto.Enabled = true;
            txtNombreProducto.Enabled = true;
            txtTipoProducto.Enabled = true;
            txtCantidad.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }


        void Deshabilitar()
        {
            txtCodProducto.Enabled = false;
            txtNombreProducto.Enabled = false;
            txtTipoProducto.Enabled = false;
            txtCantidad.Enabled = false;

            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;

            btnNuevo.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
