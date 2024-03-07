using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class ScheduledTask
    {
        public decimal IdTask { get; set; }
        public string? Nombre { get; set; }
        public DateTime? Hora { get; set; }
        public string? Estado { get; set; }
        public string? Descripcion { get; set; }
        public decimal? IdServer { get; set; }
        public decimal? IdArea { get; set; }

        public virtual Area? IdAreaNavigation { get; set; }
        public virtual Servidor? IdServerNavigation { get; set; }
    }
}
