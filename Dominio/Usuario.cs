using System;

namespace Dominio
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual long NumeroDocumento { get; set; }
        public virtual bool SuperUsuario { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Clave { get; set; }
        public virtual bool BorradoLogico {get; set; }
        public virtual DateTime Fecha  { get; set; }
    }
}
