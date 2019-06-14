using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL
{
    public class roles
    {
         public string CodRoles { get; set; }
         public string Descripcion { get; set; }

        public roles ()
        {

        }

        public roles (string codrol, string descripcion)
        {
            this.CodRoles = codrol;
            this.Descripcion = descripcion;
        }

    }
}
