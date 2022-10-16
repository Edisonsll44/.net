using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulpslit.Api.AccesoDatos
{
    public class UsuarioEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<UsuarioEntity> entityBuilder)
        {
            entityBuilder.HasKey(x=> x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.HasOne("Id").WithOne("PersonaId");
        }
    }
}
