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

        //Datos para completar datos envio
        public virtual string Calle { get; set; }
        public virtual long NumeroCalle { get; set; }
        public virtual string Localidad { get; set; }
        public virtual string Provincia { get; set; }
        public virtual long CodigoPostal { get; set; }
        public virtual long Telefono { get; set; }
        //
        public virtual bool BorradoLogico { get; set; }
        public virtual DateTime Fecha { get; set; }

        public Usuario()
        {
            this.Fecha = DateTime.Now;
            this.BorradoLogico = false;
            this.SuperUsuario = false;
        }

    }
}
