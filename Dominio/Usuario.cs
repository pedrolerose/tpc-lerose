using System;

namespace Dominio
{
    public class Usuario : EntidadBase<long>
    {
        public virtual string Mail { get; set; }
        public virtual long NumeroDeDocumento { get; set; }
        public virtual bool EsSuperUsuario { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Clave { get; set; }
        public virtual DatosEnvio DatosEnvio { get; set; }
    }
}
