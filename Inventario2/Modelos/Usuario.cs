using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class Usuario
    {
        public decimal? IdUser { get; set; }
        public string? Usuario1 { get; set; }
        public byte[]? PasswordUser { get; set; }
        public string? Permisos { get; set; }
        public string? Autenticacion { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
