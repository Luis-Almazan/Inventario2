using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class DetalleActualizacion
    {
        public decimal IdDetalle { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public decimal? IdActualizacion { get; set; }

        public virtual TipoActualizacion? IdActualizacionNavigation { get; set; }
    }
}
