using System;

namespace Dominio
{
    public class Marca : EntidadBase<long>
    {
        public Marca() { }
        public Marca(int id, string desc)
        {
            Id = id;
            Descripcion = desc;
        }

        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
