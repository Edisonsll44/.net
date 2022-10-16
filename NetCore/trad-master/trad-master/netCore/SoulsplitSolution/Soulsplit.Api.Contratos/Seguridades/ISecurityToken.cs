using System;

namespace Soulsplit.Api.Contratos.Seguridad
{
    public interface ISecurityToken
    {
        string CrearToken(string nombreUsuario, Guid usuarioId, string email);
    }
}
