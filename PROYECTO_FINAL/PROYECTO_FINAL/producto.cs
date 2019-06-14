using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL
{
    public class producto
    {
        public string CodSucursal { get; set; }
        public string CodProducto { get; set; }
        public string NombreProducto { get; set; }
        public string TipoProducto { get; set; }
        public string Cantidad { get; set; }

        public producto()
        {

        }
        public producto (string pCodSucursal, string pCodProducto, string pNombreProducto, string pTipoProducto, string pCantidad)
        {
            this.CodSucursal = pCodSucursal;
            this.CodProducto = pCodProducto;
            this.NombreProducto = pNombreProducto;
            this.TipoProducto = pTipoProducto;
            this.Cantidad = pCantidad;
        }

    }
}
