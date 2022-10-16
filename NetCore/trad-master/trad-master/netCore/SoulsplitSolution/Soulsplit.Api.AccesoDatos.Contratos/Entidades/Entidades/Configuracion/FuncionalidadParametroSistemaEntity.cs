using System;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public class FuncionalidadParametroSistemaEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set ; }

        #region Relaciones
        public Guid FuncionalidadId { get; set; }
        public virtual FuncionalidadEntity Funcionalidad { get; set; }
        public Guid ParametroSistemaId { get; set; }
        public virtual ParametroSistemaEntity ParametroSistema { get; set; }
        #endregion
    }
}
