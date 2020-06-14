using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Provincias
    {
        public virtual int Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual bool BorradoLogico { get; set; }
    }
}
