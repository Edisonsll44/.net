using System;

namespace Soulsplit.Api.AccesoDatos.Contratos.Repositorios
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
