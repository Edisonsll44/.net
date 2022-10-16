using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public interface IPagoRepository : IRepositoryGenerico<PagoEntity>
    {

        Task<IEnumerable<PagoEntity>> ConsultarPagos(DtoConsultaPago dto);
    }
}
