using System;

namespace Dominio
{
    public class Categoria : EntidadBase<long>
    {
        public Categoria() { }
        public Categoria(int id, string desc)
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
