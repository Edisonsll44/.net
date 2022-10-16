using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class FormaPagoService : IFormaPagoService
    {
        private readonly IFormaPagoRepository _formaPagoRepository;
        public FormaPagoService(IFormaPagoRepository formaPagoRepository)
        {
            _formaPagoRepository = formaPagoRepository;
        }

        public async Task<IEnumerable<DtoCombo>> ObtenerFormasPago()
        {
            var FormaPago = await _formaPagoRepository.GetAll();
            return await FormaPagoMapper.Map(FormaPago);
        }
    }
}
