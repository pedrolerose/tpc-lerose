using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FormaPago : EntidadBase<int>
    {
        public long NumeroTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public int VencimientoDia { get; set; }
        public int VencimientoMes { get; set; }
        public int CodigoSeguridad { get; set; }
    }
}
