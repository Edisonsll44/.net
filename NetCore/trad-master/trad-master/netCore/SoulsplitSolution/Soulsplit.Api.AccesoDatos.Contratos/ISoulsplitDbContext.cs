using Microsoft.EntityFrameworkCore;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public interface ISoulsplitDbContext : IDbContext
    {
        #region Tablas
        #region Catalogos
        DbSet<EstadoEnumeracionEntity> EstadosEnumeracion { get; set; }
        DbSet<DetalleEstadoEntity> DetallesEstadoEnumeracion { get; set; }
        DbSet<PaisEntity> Paises { get; set; }
        DbSet<TipoIdentificacionEntity> TipoIdentificaciones { get; set; }
        DbSet<TipoPersonaEntiy> TipoPersonas { get; set; }
        DbSet<TipoCuentaEntity> TiposCuenta { get; set; }
        #endregion
        #region Configuracion
        DbSet<MenuEntity> Menus { get; set; }
        DbSet<RolEntity> Roles { get; set; }
        DbSet<RolMenuEntity> RolesMenu { get; set; }
        DbSet<RolUsuarioEntity> RolesUsuario { get; set; }
        DbSet<ParametroSistemaEntity> ParametrosSistema { get; set; }
        DbSet<FuncionalidadParametroSistemaEntity> FuncionalidadesParametroSistema { get; set; }
        DbSet<FuncionalidadEntity> Funcionalidades { get; set; }
        #endregion
        #region Persona
        DbSet<UsuarioEntity> Usuarios { get; set; }
        DbSet<PersonaEntity> Personas { get; set; }
        DbSet<ReferidosPersonaEntity> ReferidosPersona { get; set; }
        DbSet<AuditoriaAccesoUsuarioEntity> AuditoriaAccesoUsuarios { get; set; }
        #endregion
        #region Transaccion
        DbSet<CuentaEntity> Cuentas { get; set; }
        DbSet<BancoEntity> Bancos { get; set; }
        DbSet<FormaPagoEntity> FormasPago { get; set; }
        DbSet<PagoEntity> Pagos { get; set; }
        DbSet<HistorialPagoEntity> HistorialPagos { get; set; }

        #endregion

        #endregion

    }
}
