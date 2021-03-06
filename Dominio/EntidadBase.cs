﻿using System;

namespace Dominio
{
    public abstract class EntidadBase<TipoId>
    {
        
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
            this.Usuario = new Usuario();
            this.Usuario.Id = 1;
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
