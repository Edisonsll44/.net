using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class PagoRepository : SoulsplitRepository<PagoEntity>, IPagoRepository
    {
        protected override DbSet<PagoEntity> DbEntity
        {
            get { return _soulsplitDbContext.Pagos; }
        }


        public PagoRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }


        public async Task<IEnumerable<PagoEntity>> ConsultarPagos(DtoConsultaPago dto)
        {
            var pagos = await (from x in _soulsplitDbContext.Pagos
                               where x.Estado.Equals(PropiedadesAuditoria.EstadoActivo)
                                   && (Guid.Empty.Equals(dto.EstadoId) || x.EstadoPagoId.Equals(dto.EstadoId))
                                   && (string.IsNullOrWhiteSpace(dto.Identificacion) || x.Identificacion.Contains(dto.Identificacion))
                               select x).ToListAsync();
            dto.Total = pagos.Count();
            if (dto.Registros > 0 && dto.Pagina > 0)
                return pagos?.OrderByDescending(x => x.FechaCreacion).Skip((int)dto.Registros * ((int)dto.Pagina - 1)).Take((int)dto.Registros);
            return pagos;
        }

    }
}
