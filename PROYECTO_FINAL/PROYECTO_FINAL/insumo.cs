using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL
{
    public class insumo
    {
        public string CodInsumo { get; set; }
        public string NombreInsumo { get; set; }
        public string TipoInsumo { get; set; }
        public string CantidadInsumo { get; set; }


        public insumo()
        {

        }

        public insumo(string CodInsumo, string NombreInsumo, string TipoInsumo, string cantiinsumo)
        {
            this.CodInsumo = CodInsumo;
            this.NombreInsumo = NombreInsumo;
            this.TipoInsumo = TipoInsumo;
            this.CantidadInsumo = cantiinsumo;
        }
    }
    
}
