using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsumosInformatica
{
    internal class Insumos
    {
        //variable
        private static int idProducto=0;
        //Propiedades
        public  int IdInsumo { get; set; }
        public string NombreInsumo { get; set; }
        public int CantidadInsumo { get; set; }
        public int CostoInsumo { get; set; }

   
        //Constructor por defecto
        public Insumos()
        {
            this.IdInsumo = CrearID();
        }
        //Consctructor parametrizado
        public Insumos (string nombreInsumo, int cantidadInsumo, int costoInsumo)
        {
            this.IdInsumo = CrearID();
            this.NombreInsumo = nombreInsumo;
            this.CantidadInsumo = cantidadInsumo;
            this.CostoInsumo = costoInsumo;
        }
        //Metodos
        protected int CrearID()
        {
            return ++idProducto;
        }
        public override string ToString()
        {
            return String.Format("ID {0}\t-Descripcion {1}\t-TotalExistente: {2}\t-Costo Unitario: {3}\t-Costo Total {4}",
                this.IdInsumo, this.NombreInsumo, this.CantidadInsumo, this.CostoInsumo, (this.CostoInsumo * this.CantidadInsumo));
        }
    }
}