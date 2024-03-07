using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class Sitio
    {
        public Sitio()
        {
            UrlSitios = new HashSet<UrlSitio>();
        }

        public decimal IdSitio { get; set; }
        public string? IpSecundaria { get; set; }
        public string? Status { get; set; }
        public string? Descripcion { get; set; }
        public decimal? IdServer { get; set; }
        public decimal? IdPuerto { get; set; }
        public decimal? IdServicio { get; set; }

        public virtual Puerto? IdPuertoNavigation { get; set; }
        public virtual Servidor? IdServerNavigation { get; set; }
        public virtual Servicio? IdServicioNavigation { get; set; }
        public virtual ICollection<UrlSitio> UrlSitios { get; set; }
    }
}
