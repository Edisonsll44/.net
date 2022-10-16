using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Configuraciones
{
    public class AuditoriaEntidadesService : IAuditoriaEntidadesService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AuditoriaEntidadesService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public TEntity ActualizarAuditoria<TEntity>(TEntity entidad, string token = "", string usuario = "") where TEntity : Auditoria
        {
            var usuarioAuditoria = string.IsNullOrEmpty(usuario) ? "" : usuario;
            entidad.HostNameModificacion = Environment.MachineName;
            entidad.FechaModificacion = DateTime.Now;
            entidad.UsuarioModificacion = usuarioAuditoria;
            return entidad;
        }

        public TEntity ActualizarAuditoria<TEntity>(TEntity entidad, string estado, string token = "", string usuario = "") where TEntity : Auditoria
        {
            var usuarioAuditoria = string.IsNullOrEmpty(usuario) ? "" : usuario;
            entidad.Estado = estado;
            entidad.HostNameModificacion = Environment.MachineName;
            entidad.FechaModificacion = DateTime.Now;
            entidad.UsuarioModificacion = usuarioAuditoria;
            return entidad;
        }

        public TEntity InsertarDatosAuditoria<TEntity>(TEntity entidad, string token = "", string usuario = "") where TEntity : Auditoria
        {
            var usuarioAuditoria = string.IsNullOrEmpty(usuario) ? "" : usuario;
            entidad.UsuarioCreacion = string.IsNullOrEmpty(entidad.UsuarioCreacion) ? usuarioAuditoria : entidad.UsuarioCreacion;
            entidad.FechaCreacion = DateTime.Now;
            entidad.HostNameCreacion = string.IsNullOrEmpty(entidad.HostNameCreacion) ? Environment.MachineName : entidad.HostNameCreacion;
            entidad.UsuarioModificacion = usuarioAuditoria;
            entidad.HostNameModificacion = Environment.MachineName;
            entidad.FechaModificacion = DateTime.Now;
            entidad.Estado = PropiedadesAuditoria.EstadoActivo;
            return entidad;
        }

        public async Task<UsuarioEntity> ObtenerUsuario(string token)
        {
            UsuarioEntity usuario = await _usuarioRepository.GetOneAsync<UsuarioEntity>(x => x.Token.Equals(token) && x.Estado.Equals(PropiedadesAuditoria.EstadoActivo));
            if (usuario is null)
                throw new UnauthorizedAccessException("Usuario no encontrado");
            return usuario;
        }
    }
}
