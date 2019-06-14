using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL
{
    class Mermas
    {
        //Variables 
        private string CodSucursal;
        private string CodProducto;
        private int CantidadMerma;
        private DateTime FechaInicio;
        private DateTime FechaFin;
        public Mermas()
        {
            this.CodSucursal1 = CodSucursal;
            this.CodProducto1 = CodProducto;
            this.CantidadMerma1 = CantidadMerma;
            this.FechaInicio1 = FechaInicio;
            this.FechaFin1 = FechaFin;
        }

        //Constructor
        public Mermas(string CodSucursal, string CodProucto,int CantidadMerma, DateTime FechaInicio, DateTime FechaFin)
        {
            CodSucursal1 = CodSucursal;
            CodProducto1 = CodProducto;
            CantidadMerma1 = CantidadMerma;
            FechaInicio1 = FechaInicio;
            FechaFin1 = FechaFin;
        }

        //Getters y Setters de todas las variables
        public string CodSucursal1 { get => CodSucursal; set => CodSucursal = value; }
        public string CodProducto1 { get => CodProducto; set => CodProducto = value; }
        public int CantidadMerma1 { get => CantidadMerma; set => CantidadMerma = value; }
        public DateTime FechaInicio1 { get => FechaInicio; set => FechaInicio = value; }
        public DateTime FechaFin1 { get => FechaFin; set => FechaFin = value; }

    }
}

