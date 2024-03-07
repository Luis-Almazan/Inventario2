using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class Servicio
    {
        public Servicio()
        {
            Sitios = new HashSet<Sitio>();
        }

        public decimal IdServicio { get; set; }
        public string? NombreServicio { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Sitio> Sitios { get; set; }
    }
}
