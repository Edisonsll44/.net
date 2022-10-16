using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Soulpslit.Api.AccesoDatos;
using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulsplit.Api.ResolucionDependencia
{
    public static class IoCRegisterDataContext
    {
        public static IServiceCollection AddRegisterContext(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ISoulsplitDbContext, SoulsplitDbContext>();
            services.AddDbContext<SoulsplitDbContext>(opt => opt.UseLazyLoadingProxies().UseNpgsql(connectionString));
            return services;
        }
    }
}
