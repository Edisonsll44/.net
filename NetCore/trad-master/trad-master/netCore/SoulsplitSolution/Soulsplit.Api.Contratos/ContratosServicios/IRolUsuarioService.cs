using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IRolUsuarioService
    {
        Task<DtoRespuesta> CrearRolUsuario(RolUsuarioDto nuevoRol);
        Task<DtoRespuesta> CrearRolUsuario(Guid rolId, Guid usuarioId);
        Task<DtoRespuesta> EditarRolUsuario(Guid rolId, Guid rolusuarioId, string token);
    }
}