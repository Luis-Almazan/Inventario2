using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class Puerto
    {
        public Puerto()
        {
            Sitios = new HashSet<Sitio>();
        }

        public decimal IdPuerto { get; set; }
        public decimal? NoPuerto { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Sitio> Sitios { get; set; }
    }
}
