using Soulsplit.Api.Utilitarios.Enumeraciones;

namespace Soulsplit.Api.Utilitarios.Propiedades
{
    public static class PropiedadesAuditoria
    {
        public static string EstadoActivo => nameof(EstadosEntidad.Activo).ToUpper();

        /// <summary>
        /// Contiene el valor del estado inactivo
        /// </summary>
        public static string EstadoInactivo => nameof(EstadosEntidad.Inactivo).ToUpper();
    }
}
