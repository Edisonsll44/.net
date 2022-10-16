using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IPaisService
    {
        Task<PaisEntity> ObtenerPais(Guid id);
        Task<DtoRespuesta> CrearPais(Pais nuevoPais);
        Task<DtoRespuesta> ActualizarPais(Pais pais);
        Task<DtoRespuesta> EliminarPais(Guid idPais, int accion);
        Task<List<Pais>> ObtenerPaises();

        Task CrearPaises();
    }
}
