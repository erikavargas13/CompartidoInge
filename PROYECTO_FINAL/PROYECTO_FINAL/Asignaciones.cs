using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL
{
    public class Asigaciones
    {
        public string Codigo_Origen { get; set; }
        public string Codigo_Destino { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public Asigaciones() { }

        public Asigaciones(string pCodigo_Origen, string pCodigo_Destino, string pProducto, int pCantidad, DateTime pFecha)

        {
            this.Codigo_Origen = pCodigo_Origen;
            this.Codigo_Destino = pCodigo_Destino;
            this.Producto = pProducto;
            this.Cantidad = pCantidad;
            this.Fecha = pFecha;
        }
    }
}
