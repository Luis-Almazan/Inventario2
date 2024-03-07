using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class Area
    {
        public Area()
        {
            ScheduledTasks = new HashSet<ScheduledTask>();
            Servidors = new HashSet<Servidor>();
        }

        public decimal IdArea { get; set; }
        public string? NombreArea { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<ScheduledTask> ScheduledTasks { get; set; }
        public virtual ICollection<Servidor> Servidors { get; set; }
    }
}
