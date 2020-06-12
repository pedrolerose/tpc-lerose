using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Localidad : EntidadBase<long>
    {
        public virtual string Descripcion { get; set; }
    }
}
