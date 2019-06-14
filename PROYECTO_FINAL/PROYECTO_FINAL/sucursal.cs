using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL
{
    public class sucursal
    {
        //Variables 
        public string CodSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string DireccionSucural { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int TelefonoSucursal { get; set; }

        public sucursal()
        {

        }

        //Constructor
        public sucursal(string CodSucursal, string NombreSucursal, string DireccionSucural, double Latitud, double Longitud, int TelefonoSucursal)
        {

            this.CodSucursal = CodSucursal;
            this.NombreSucursal = NombreSucursal;
            this.DireccionSucural = DireccionSucural;
            this.Latitud = Latitud;
            this.Longitud = Longitud;
            this.TelefonoSucursal = TelefonoSucursal;

        }
            
    }

        
}
