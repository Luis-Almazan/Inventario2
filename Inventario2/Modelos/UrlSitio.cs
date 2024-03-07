using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class UrlSitio
    {
        public decimal IdUrl { get; set; }
        public string? UrlSitio1 { get; set; }
        public string? Descripcion { get; set; }
        public decimal? IdSitio { get; set; }

        public virtual Sitio? IdSitioNavigation { get; set; }
    }
}
