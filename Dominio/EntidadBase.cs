using System;

namespace Dominio
{
    public abstract class EntidadBase<TipoId>
    {
        [NonSerialized()]
        protected string _codigoHash;
        protected bool _activo = true;

        [NonSerialized()]
        private bool _borradoLogico;

        [NonSerialized()]
        private Usuario _usuario;

        [NonSerialized()]
        private DateTime _fecha;


        public EntidadBase()
            : base()
        {
            BorradoLogico = false;
            Fecha = DateTime.Now;
           // this.Usuario = AplicacionContexto.getUserContext() as Usuario;
        }

        protected TipoId _id;

        public virtual TipoId Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual bool BorradoLogico
        {
            get { return _borradoLogico; }
            set { _borradoLogico = value; }
        }

        public virtual Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }


        public virtual DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }


    }
}
