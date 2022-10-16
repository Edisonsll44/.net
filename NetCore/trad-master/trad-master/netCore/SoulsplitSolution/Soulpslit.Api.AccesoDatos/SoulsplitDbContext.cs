using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;
using System.Linq;

namespace Soulpslit.Api.AccesoDatos
{
    public class SoulsplitDbContext : DbContext, ISoulsplitDbContext
    {
        #region Tablas
        #region Catalogos
        public DbSet<EstadoEnumeracionEntity> EstadosEnumeracion { get; set; }
        public DbSet<DetalleEstadoEntity> DetallesEstadoEnumeracion { get; set; }
        public DbSet<PaisEntity> Paises { get; set; }
        public DbSet<TipoIdentificacionEntity> TipoIdentificaciones { get; set; }
        public DbSet<TipoPersonaEntiy> TipoPersonas { get; set; }
        public DbSet<TipoCuentaEntity> TiposCuenta { get; set; }
        #endregion
        #region Configuracion
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<RolEntity> Roles { get; set; }
        public DbSet<RolMenuEntity> RolesMenu { get; set; }
        public DbSet<RolUsuarioEntity> RolesUsuario { get; set; }
        #endregion
        #region Persona
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<PersonaEntity> Personas { get; set; }
        public DbSet<ReferidosPersonaEntity> ReferidosPersona { get; set; }
        public DbSet<AuditoriaAccesoUsuarioEntity> AuditoriaAccesoUsuarios { get; set; }
        #endregion
        #region Transaccion
        public DbSet<CuentaEntity> Cuentas { get; set; }
        public DbSet<BancoEntity> Bancos { get; set; }
        public DbSet<FormaPagoEntity> FormasPago { get; set; }
        public DbSet<PagoEntity> Pagos { get; set; }
        public DbSet<HistorialPagoEntity> HistorialPagos { get; set; }
        public DbSet<FuncionalidadEntity> Funcionalidades { get; set; }
        public DbSet<FuncionalidadParametroSistemaEntity> FuncionalidadesParametroSistema { get; set; }
        public DbSet<ParametroSistemaEntity> ParametrosSistema { get; set; }

        #endregion

        #endregion

        public SoulsplitDbContext(DbContextOptions options) : base(options)
        {
        }
        public SoulsplitDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
                property.SetColumnType("decimal(20, 6)");
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
                property.SetColumnType("varchar");


            #region Indices
            #region Unicos

            modelBuilder.Entity<EstadoEnumeracionEntity>().HasIndex(b => b.Nombre).HasDatabaseName("IX_NombreEstado").IsUnique();
            modelBuilder.Entity<RolEntity>().HasIndex(b => b.NombreRol).HasDatabaseName("IX_NombreRol").IsUnique();
            modelBuilder.Entity<PaisEntity>().HasIndex(b => b.NombrePais).HasDatabaseName("IX_NombrePais").IsUnique();
            modelBuilder.Entity<UsuarioEntity>().HasIndex(b => b.Email).HasDatabaseName("IX_EmailUsuario").IsUnique();
            modelBuilder.Entity<ParametroSistemaEntity>().HasIndex(b => b.NombreParametro).HasDatabaseName("IX_NombreParametro").IsUnique();
            modelBuilder.Entity<FuncionalidadEntity>().HasIndex(b => b.NombreFuncionalidad).HasDatabaseName("IX_NombreFuncionalidad").IsUnique();
            modelBuilder.Entity<PersonaEntity>().HasIndex(x => new { x.Identificacion }).HasDatabaseName("IX_Identificacion").IsUnique();
            modelBuilder.Entity<BancoEntity>().HasIndex(x => new { x.Codigo }).HasDatabaseName("IX_CodigoBanco").IsUnique();
            modelBuilder.Entity<TipoCuentaEntity>().HasIndex(x => new { x.Codigo }).HasDatabaseName("IX_CodigoTipoCuenta").IsUnique();
            modelBuilder.Entity<FormaPagoEntity>().HasIndex(x => new { x.Codigo }).HasDatabaseName("IX_CodigoformaPago").IsUnique();

            #endregion
            #region Compuestos

            modelBuilder.Entity<DetalleEstadoEntity>().HasIndex(x => new { x.Nombre, x.Estado }).HasDatabaseName("IX_NombreDetalleEstado").IsUnique();

            modelBuilder.Entity<MenuEntity>().HasIndex(x => new { x.NombrePagina, x.PadreId }).HasDatabaseName("IX_NombrePagina").IsUnique();
            modelBuilder.Entity<RolMenuEntity>().HasIndex(x => new { x.MenuId, x.RolId }).HasDatabaseName("IX_MenuRol").IsUnique();
            modelBuilder.Entity<RolUsuarioEntity>().HasIndex(x => new { x.RolId, x.UsuarioId }).HasDatabaseName("IX_RolUsuario").IsUnique();
            modelBuilder.Entity<CuentaEntity>().HasIndex(x => new { x.NumeroCuenta, x.BancoId, x.TipoCuentaId }).HasDatabaseName("IX_CuentaBancoTipoCuenta").IsUnique();
            #endregion
            #endregion


        }
    }
}
