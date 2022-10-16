using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public class Auditoria
    {
        [Required]

        [StringLength(10)]
        [DefaultValue("ACTIVO")]
        public string Estado { get; set; }
        [Required]
        [DefaultValue("ADM-SOULSPLIT")]
        [StringLength(maximumLength: 80)]
        public string UsuarioCreacion { get; set; }

        [DefaultValue("ADM-SOULSPLIT")]
        [StringLength(maximumLength: 80)]
        public string UsuarioModificacion { get; set; }

        [StringLength(maximumLength: 80)]
        [DefaultValue("HOST")]
        public string HostNameCreacion { get; set; }
        [StringLength(maximumLength: 80)]
        [DefaultValue("HOST")]
        public string HostNameModificacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
