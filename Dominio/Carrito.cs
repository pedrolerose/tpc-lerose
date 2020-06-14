using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Carrito : EntidadBase<long>
    {
        public virtual List<Articulo> Articulos { get; set; }
        public virtual decimal Monto { get; set; }
        public virtual DatosEnvio DatosEnvio { get; set; }
    }
}
