using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Provincia : EntidadBase<long>
    {
        public virtual string Descripcion { get; set; }
    }
}
