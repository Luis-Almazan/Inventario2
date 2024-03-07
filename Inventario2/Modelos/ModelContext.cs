using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
namespace Inventario2.Modelos
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }
        private readonly IConfiguration _configuration;
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ambiente> Ambientes { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<DetalleActualizacion> DetalleActualizacions { get; set; } = null!;
        public virtual DbSet<Puerto> Puertos { get; set; } = null!;
        public virtual DbSet<ScheduledTask> ScheduledTasks { get; set; } = null!;
        public virtual DbSet<Server> Servers { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<Servidor> Servidors { get; set; } = null!;
        public virtual DbSet<Sitio> Sitios { get; set; } = null!;
        public virtual DbSet<TipoActualizacion> TipoActualizacions { get; set; } = null!;
        public virtual DbSet<UrlSitio> UrlSitios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                string connectionString = _configuration.GetConnectionString("MiConexion");
                optionsBuilder.UseOracle(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ARQUI")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Ambiente>(entity =>
            {
                entity.HasKey(e => e.IdAmbiente);

                entity.ToTable("AMBIENTE");

                entity.Property(e => e.IdAmbiente)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_AMBIENTE");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.NombreAmbiente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_AMBIENTE");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.ToTable("AREA");

                entity.Property(e => e.IdArea)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_AREA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.NombreArea)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_AREA");
            });

            modelBuilder.Entity<DetalleActualizacion>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.ToTable("DETALLE_ACTUALIZACION");

                entity.Property(e => e.IdDetalle)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_DETALLE");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_ACTUALIZACION");

                entity.Property(e => e.IdActualizacion)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_ACTUALIZACION");

                entity.HasOne(d => d.IdActualizacionNavigation)
                    .WithMany(p => p.DetalleActualizacions)
                    .HasForeignKey(d => d.IdActualizacion)
                    .HasConstraintName("DETALLE_UPDATE_TIPO_UPDATE_FK");
            });

            modelBuilder.Entity<Puerto>(entity =>
            {
                entity.HasKey(e => e.IdPuerto);

                entity.ToTable("PUERTO");

                entity.Property(e => e.IdPuerto)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_PUERTO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.NoPuerto)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NO_PUERTO");
            });

            modelBuilder.Entity<ScheduledTask>(entity =>
            {
                entity.HasKey(e => e.IdTask);

                entity.ToTable("SCHEDULED_TASK");

                entity.Property(e => e.IdTask)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_TASK");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .IsFixedLength();

                entity.Property(e => e.Hora)
                    .HasColumnType("DATE")
                    .HasColumnName("HORA");

                entity.Property(e => e.IdArea)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_AREA");

                entity.Property(e => e.IdServer)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_SERVER");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.ScheduledTasks)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("SCHEDULED_TASK_AREA_FK");

                entity.HasOne(d => d.IdServerNavigation)
                    .WithMany(p => p.ScheduledTasks)
                    .HasForeignKey(d => d.IdServer)
                    .HasConstraintName("SCHEDULED_TASK_SERVIDOR_FK");
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SERVER");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.DnsBalanceador)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DNS_BALANCEADOR");

                entity.Property(e => e.DnsHost)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DNS_HOST");

                entity.Property(e => e.Hostname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HOSTNAME");

                entity.Property(e => e.IdSrv)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_SRV");

                entity.Property(e => e.Internet)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("INTERNET");

                entity.Property(e => e.IpBalanceador)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IP_BALANCEADOR");

                entity.Property(e => e.IpPrincipal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IP_PRINCIPAL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACIONES");

                entity.Property(e => e.Procesador)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PROCESADOR");

                entity.Property(e => e.Ram)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RAM");

                entity.Property(e => e.SistemaOperativo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SISTEMA_OPERATIVO");

                entity.Property(e => e.Webserver)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSERVER");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio);

                entity.ToTable("SERVICIO");

                entity.Property(e => e.IdServicio)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_SERVICIO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_SERVICIO");
            });

            modelBuilder.Entity<Servidor>(entity =>
            {
                entity.HasKey(e => e.IdServer);

                entity.ToTable("SERVIDOR");

                entity.Property(e => e.IdServer)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_SERVER");

                entity.Property(e => e.Core)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CORE");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Hostname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HOSTNAME");

                entity.Property(e => e.IdAmbiente)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_AMBIENTE");

                entity.Property(e => e.IdArea)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_AREA");

                entity.Property(e => e.Internet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERNET")
                    .IsFixedLength();

                entity.Property(e => e.IpPrimaria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP_PRIMARIA");

                entity.Property(e => e.NameDns)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_DNS");

                entity.Property(e => e.NombreServer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_SERVER");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACIONES");

                entity.Property(e => e.Ram)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RAM");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.HasOne(d => d.IdAmbienteNavigation)
                    .WithMany(p => p.Servidors)
                    .HasForeignKey(d => d.IdAmbiente)
                    .HasConstraintName("SERVIDOR_AMBIENTE_FK");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Servidors)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("SERVIDOR_AREA_FK");
            });

            modelBuilder.Entity<Sitio>(entity =>
            {
                entity.HasKey(e => e.IdSitio);

                entity.ToTable("SITIO");

                entity.Property(e => e.IdSitio)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_SITIO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdPuerto)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_PUERTO");

                entity.Property(e => e.IdServer)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_SERVER");

                entity.Property(e => e.IdServicio)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_SERVICIO");

                entity.Property(e => e.IpSecundaria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IP_SECUNDARIA");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.HasOne(d => d.IdPuertoNavigation)
                    .WithMany(p => p.Sitios)
                    .HasForeignKey(d => d.IdPuerto)
                    .HasConstraintName("SITIO_PUERTO_FK");

                entity.HasOne(d => d.IdServerNavigation)
                    .WithMany(p => p.Sitios)
                    .HasForeignKey(d => d.IdServer)
                    .HasConstraintName("SITIO_SERVIDOR_FK");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Sitios)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("SITIO_SERVICIO_FK");
            });

            modelBuilder.Entity<TipoActualizacion>(entity =>
            {
                entity.HasKey(e => e.IdActualizacion);

                entity.ToTable("TIPO_ACTUALIZACION");

                entity.Property(e => e.IdActualizacion)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_ACTUALIZACION");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.NombreActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_ACTUALIZACION");
            });

            modelBuilder.Entity<UrlSitio>(entity =>
            {
                entity.HasKey(e => e.IdUrl);

                entity.ToTable("URL_SITIO");

                entity.Property(e => e.IdUrl)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_URL");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdSitio)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_SITIO");

                entity.Property(e => e.UrlSitio1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("URL_SITIO");

                entity.HasOne(d => d.IdSitioNavigation)
                    .WithMany(p => p.UrlSitios)
                    .HasForeignKey(d => d.IdSitio)
                    .HasConstraintName("URL_SITIO_SITIO_FK");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USUARIO");

                entity.Property(e => e.Autenticacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AUTENTICACION");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_ACTUALIZACION");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_INGRESO");

                entity.Property(e => e.IdUser)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_USER");

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(64)
                    .HasColumnName("PASSWORD_USER");

                entity.Property(e => e.Permisos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PERMISOS");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
