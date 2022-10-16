
using Soulsplit.Api.Utilitarios.Enumeraciones.Configuraciones;

namespace Soulsplit.Api.Utilitarios.Enumeraciones
{
    public enum EstadosEntidad
    {
        Activo = 1,
        Inactivo = 2,
        Todos = 3
    }

    public enum OperacionesBdd
    {
        [ExtensionEnum("INSERTAR")]
        Insertar = 1,
        [ExtensionEnum("ACTUALIZAR")]
        Actualizar = 2,
        [ExtensionEnum("ELIMINAR")]
        Eliminar = 3,
        [ExtensionEnum("REACTIVAR")]
        Reactivar = 4
    }
    public enum Procesos
    {
        [ExtensionEnum("PAGOS")]
        PAGOS,
    }

    public enum EstadoPago
    {
        [ExtensionEnum("EN PROCESO")]
        EN_PROCESO,
        [ExtensionEnum("APROBADO")]
        APROBADO,
        [ExtensionEnum("RECHAZADO")]
        RECHAZADO,
    }

    public enum Roles
    {
        [ExtensionEnum("USUARIO")]
        USUARIO,
        [ExtensionEnum("ADMINISTRADOR")]
        ADMINISTRADOR
    }

    public enum TipoDocumentoIdentificacion
    {
        [ExtensionEnum("CEDULA")]
        CEDULA,
        [ExtensionEnum("RUC")]
        RUC,
        [ExtensionEnum("CEDULA DE EXTRANJERO")]
        CEDULA_EXTRANJERO,
        [ExtensionEnum("NIT", "1")]
        NIT,
        [ExtensionEnum("CEDULA DE CIUDADANIA", "2")]
        CEDULA_CIUDADANIA,
        [ExtensionEnum("CEDULA DE RESIDENCIA", "3")]
        CEDULA_RESIDENCIA,
        [ExtensionEnum("TARJETA DE IDENTIDAD", "4")]
        TARJETA_IDENTIDAD,
        [ExtensionEnum("PASAPORTE", "6")]
        PASAPORTE,
    }

    public enum CodigoPais
    {
        [ExtensionEnum("ECUADOR", "ECUADOR")]
        ECUADOR = 1,
        [ExtensionEnum("COLOMBIA", "COLOMBIA")]
        COLOMBIA = 2,
    }

    public enum Funcionalidades
    {
        [ExtensionEnum("Email Contactanos", "Email Contactanos")]
        EmailContacto,
    }

    public enum Canales
    {
        [ExtensionEnum("canal-pago")]
        Pagos,
        [ExtensionEnum("canal-usuario-")]
        Usuario
    }
    public enum Eventos
    {
        [ExtensionEnum("pago-creado-usuario")]
        CreacionPagoUsuario,
        [ExtensionEnum("pago-actualizado-usuario")]
        ActualizacionPagoUsuario,
        [ExtensionEnum("pago-creado")]
        CreacionPago,
        [ExtensionEnum("pago-actualizado")]
        ActualizacionPago
    }

    public enum Acciones
    {
        Modificar = 1,
        Eliminar = 2,
        Reactivar = 3
    }
}
