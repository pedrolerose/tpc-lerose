using System;
using System.Collections.Generic;

namespace Dominio
{
    public class DatosEnvio : EntidadBase<long>
    {
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual long Documento { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Calle { get; set; }
        public virtual long Numero { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual long CodigoPostal { get; set; }
        public virtual long Telefono { get; set; }
        public virtual string Notas { get; set; }
    }
}
