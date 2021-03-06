﻿using System;
using System.Collections.Generic;

namespace Dominio
{
    public class DatosEnvio : EntidadBase<int>
    {
        public virtual string Nombre { get; set; }
        public virtual long NumeroDocumento { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Calle { get; set; }
        public virtual long NumeroCalle { get; set; }
        public virtual string Localidad { get; set; }
        public virtual string Provincia { get; set; }
        public virtual long CodigoPostal { get; set; }
        public virtual long Telefono { get; set; }
        public virtual string Notas { get; set; }
    }
}
