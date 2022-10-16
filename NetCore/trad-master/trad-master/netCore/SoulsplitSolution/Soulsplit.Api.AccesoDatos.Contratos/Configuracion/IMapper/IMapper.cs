namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public interface IMapper<T, R> where T : BaseBusinessModel where R : class
    {
        T Map(R dto);
        R Map(T dto);
    }
}
