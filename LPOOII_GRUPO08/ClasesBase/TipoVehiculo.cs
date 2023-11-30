using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TipoVehiculo
    {
        private int tvCodigo;
        private string descripcion;
        private decimal tarifa;
        private string imagen;
        public int TVCodigo
        {
            get { return tvCodigo; }
            set { tvCodigo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public decimal Tarifa
        {
            get { return tarifa; }
            set { tarifa = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        
    }
}
