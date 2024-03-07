using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class TipoActualizacion
    {
        public TipoActualizacion()
        {
            DetalleActualizacions = new HashSet<DetalleActualizacion>();
        }

        public decimal IdActualizacion { get; set; }
        public string? NombreActualizacion { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<DetalleActualizacion> DetalleActualizacions { get; set; }
    }
}
