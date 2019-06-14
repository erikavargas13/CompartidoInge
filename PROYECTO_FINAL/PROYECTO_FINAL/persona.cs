using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL
{
    public class persona
    {
        public string CodigoPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string TelefonoPersona { get; set; }
        public string PassPersona { get; set; }

        public persona()
        {

        }
        public persona (string CodigoPersona, string passpersona)
        {
            this.CodigoPersona = CodigoPersona;
            this.PassPersona = passpersona;
        }
    }
}
