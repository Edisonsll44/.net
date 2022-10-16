using Soulsplit.Api.AccesoDatos.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.Configuraciones
{
    public interface IBaseCrudService<TEntity> where TEntity : BaseBusinessModel
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> Update(TEntity entity);
    }
}
