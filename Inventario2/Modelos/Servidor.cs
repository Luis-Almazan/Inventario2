using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class Servidor
    {
        public Servidor()
        {
            ScheduledTasks = new HashSet<ScheduledTask>();
            Sitios = new HashSet<Sitio>();
        }

        public decimal IdServer { get; set; }
        public string? IpPrimaria { get; set; }
        public string? NombreServer { get; set; }
        public string? Hostname { get; set; }
        public string? NameDns { get; set; }
        public decimal? Ram { get; set; }
        public decimal? Core { get; set; }
        public string? Status { get; set; }
        public string? Internet { get; set; }
        public string? Descripcion { get; set; }
        public string? Observaciones { get; set; }
        public decimal? IdArea { get; set; }
        public decimal? IdAmbiente { get; set; }

        public virtual Ambiente? IdAmbienteNavigation { get; set; }
        public virtual Area? IdAreaNavigation { get; set; }
        public virtual ICollection<ScheduledTask> ScheduledTasks { get; set; }
        public virtual ICollection<Sitio> Sitios { get; set; }
    }
}
