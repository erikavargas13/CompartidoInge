using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL
{
    class detallestock
    {

        public int CantidadDetalle { get; set; }
        public string NombreProducto { get; set; }


        public detallestock()
        {

        }

        public detallestock(int cantidaddetalle, string nombreproducto)
        {
            this.CantidadDetalle = cantidaddetalle;
            this.NombreProducto = nombreproducto;
        }
    }
}
