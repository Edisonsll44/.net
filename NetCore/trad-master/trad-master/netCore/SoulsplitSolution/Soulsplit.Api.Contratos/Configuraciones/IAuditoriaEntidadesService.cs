using Soulsplit.Api.AccesoDatos.Contratos;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IAuditoriaEntidadesService
    {
        /// <summary>
        /// Inserta los datos de auditoria en una
        /// entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entidad"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        TEntity InsertarDatosAuditoria<TEntity>(TEntity entidad, string token = "", string usuario = "") where TEntity : Auditoria;

        /// <summary>
        /// Actualiza los datos de auditoria de
        /// una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entidad"></param>
        /// <param name="token"></param>
        /// <param name="usuario"></param>
        /// <param name="esSitionWeb"></param>
        /// <returns>Entidad con auditoria</returns>
        TEntity ActualizarAuditoria<TEntity>(TEntity entidad, string token = "", string usuario = "") where TEntity : Auditoria;

        /// <summary>
        /// Actualizar Auditoria con estado  opcional
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entidad"></param>
        /// <param name="token"></param>
        /// <param name="usuario"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        TEntity ActualizarAuditoria<TEntity>(TEntity entidad, string estado, string token = "", string usuario = "") where TEntity : Auditoria;

        Task<UsuarioEntity> ObtenerUsuario(string token);
    }
}
