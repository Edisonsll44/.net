using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IMenuService
    {
        Task<DtoRespuesta> CrearMenu(DtoMenu nuevoMenu);

        Task<IEnumerable<DtoMenu>> ObtenerMenu();
    }
}
