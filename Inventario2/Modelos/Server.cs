using System;
using System.Collections.Generic;

namespace Inventario2.Modelos
{
    public partial class Server
    {
        public decimal? IdSrv { get; set; }
        public string? IpPrincipal { get; set; }
        public string? Nombre { get; set; }
        public string? IpBalanceador { get; set; }
        public string? DnsBalanceador { get; set; }
        public string? Hostname { get; set; }
        public string? SistemaOperativo { get; set; }
        public string? DnsHost { get; set; }
        public decimal? Procesador { get; set; }
        public decimal? Ram { get; set; }
        public string? Webserver { get; set; }
        public decimal? Internet { get; set; }
        public string? Descripcion { get; set; }
        public string? Observaciones { get; set; }
    }
}
