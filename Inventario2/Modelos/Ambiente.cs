using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class Ambiente
    {
        public Ambiente()
        {
            Servidors = new HashSet<Servidor>();
        }

        public decimal IdAmbiente { get; set; }
        public string? NombreAmbiente { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Servidor> Servidors { get; set; }
    }
}
