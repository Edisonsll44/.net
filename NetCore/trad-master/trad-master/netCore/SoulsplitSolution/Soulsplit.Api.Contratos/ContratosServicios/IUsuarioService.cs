using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IUsuarioService
    {
        Task<DtoRespuesta> CrearUsuario(string nombre, string apellido, string token, Guid personaId, string nombreUsuario, string email, string clave);
        Task<DtoRespuesta> ActivarUsuario(string token);
        Task<DtoRespuesta> OlvidoClave(string email);
        Task<DtoRespuesta> ValidarToken(string token);
        Task<DtoRespuesta> CambioClave(string token, string clave);
        Task<IEnumerable<UsuarioDto>> ListaUsuarios(string token);
        Task<DtoRespuesta> CambioRolUsuario(Guid usuarioId, Guid rolId, string token);
        UsuarioEntity ObtenerUsuarioToken(string token);
    }
}
