using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EstadoVenta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool BorradoLogico { get; set; }

        public EstadoVenta()
        {
            this.Id = 3;
            this.Descripcion = "Falta Cobro";
            this.BorradoLogico = false;
        }

        public EstadoVenta(int a, string b)
        {
            this.Id = a;
            this.Descripcion = b;
            this.BorradoLogico = false;
        }
    }
}
