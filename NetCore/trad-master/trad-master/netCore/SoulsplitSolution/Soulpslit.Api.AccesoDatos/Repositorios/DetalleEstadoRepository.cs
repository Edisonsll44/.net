using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Soulsplit.Api.Utilitarios.Propiedades;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class DetalleEstadoRepository : SoulsplitRepository<DetalleEstadoEntity>, IDetalleEstadoRepository
    {
        protected override DbSet<DetalleEstadoEntity> DbEntity
        {
            get { return _soulsplitDbContext.DetallesEstadoEnumeracion; }
        }


        public DetalleEstadoRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }

        public IQueryable<DetalleEstadoEntity> ObtenerDetallesEstado(Guid idEstado = default(Guid), string cabeceraEstado = default(string))
        {
            IQueryable<DetalleEstadoEntity> detalles = from x in _soulsplitDbContext.DetallesEstadoEnumeracion//.Where(x =>
                                                       where x.Estado.Equals(PropiedadesAuditoria.EstadoActivo)
                                                           && (Guid.Empty.Equals(idEstado) || x.EstadoEnumeracionId.Equals(idEstado))
                                                           && (string.IsNullOrWhiteSpace(cabeceraEstado) || x.EstadoEnumeracion.Nombre.Equals(cabeceraEstado))
                                                       select x;
            var xs = detalles.ToList();
            return detalles;
        }
    }
}
