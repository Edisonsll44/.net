using Newtonsoft.Json;
using RestSharp;
using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios.Enumeraciones;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _paisRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public PaisService(IPaisRepository paisRepository, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _paisRepository = paisRepository;
        }

        public async Task<DtoRespuesta> CrearPais(Pais nuevoPais)
        {
            var paisMapeado = PaisMapper.Map(nuevoPais);
            _auditoriaEntidadesService.InsertarDatosAuditoria(paisMapeado, usuario: "adm");
            await _paisRepository.Add(paisMapeado);
            return await Respuesta.DevolverRespuesta("País", "creado");
        }

        public async Task<DtoRespuesta> ActualizarPais(Pais pais)
        {
            var paisMapeado = PaisMapper.Map(pais);
            var paisEncontrado = await ObtenerPais(paisMapeado.Id);
            if (paisEncontrado != null)
            {
                _auditoriaEntidadesService.ActualizarAuditoria(paisMapeado, usuario: "adm");
                await _paisRepository.Update(paisMapeado);
                return await Respuesta.DevolverRespuesta("País", "modificado");
            }
            throw new Exception("Pais no encontrado.");
        }

        public async Task<DtoRespuesta> EliminarPais(Guid idPais, int accion)
        {
            var paisEncontrado = await ObtenerPais(idPais);
            if (paisEncontrado != null)
            {
                if (accion == (int)OperacionesBdd.Eliminar)
                {
                    _auditoriaEntidadesService.ActualizarAuditoria(entidad: paisEncontrado, estado: PropiedadesAuditoria.EstadoInactivo, usuario: "adm");
                }
                else
                {
                    _auditoriaEntidadesService.ActualizarAuditoria(entidad: paisEncontrado, estado: PropiedadesAuditoria.EstadoActivo, usuario: "adm");
                }
                await _paisRepository.Update(paisEncontrado);
                return await Respuesta.DevolverRespuesta("País", accion == (int)OperacionesBdd.Eliminar ? "eliminado" : "re activado");
            }
            throw new Exception("Pais no encontrado.");
        }


        public async Task<PaisEntity> ObtenerPais(Guid id)
        {
            var paisEncontrado = await _paisRepository.Get(id);
            return paisEncontrado;
        }

        public async Task<List<Pais>> ObtenerPaises()
        {
            var paises = await _paisRepository.ObtenerPaises();
            return await PaisMapper.Map(paises);
        }

        public async Task CrearPaises()
        {

            var client = new RestClient("https://restcountries.eu/rest/v2/")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            List<DtoPais> paises = JsonConvert.DeserializeObject<List<DtoPais>>(response.Content);
            foreach (var item in paises)
            {
                PaisEntity pais = await _paisRepository.GetOneAsync<PaisEntity>(x => x.NombrePais.Equals(item.name));

                try
                {

                    if (pais is null)
                    {
                        await CrearPais(new Pais()
                        {
                            Nombre = item.name,
                            Bandera = item.flag,
                            Latitud = item?.latlng?.Count() > 0 ? item?.latlng[0] ?? 0 : 0,
                            Longitud = item?.latlng?.Count() > 0 ? item?.latlng[1] ?? 0 : 0,
                            CodigoRegional = item.callingCodes[0],
                            CodigoPais = item.alpha2Code,
                            Nacionalidad = item.demonym
                        });
                    }
                    else
                    {
                            pais.NombrePais = item.name;
                            pais.Bandera = item.flag;
                            pais.Latitud = item?.latlng?.Count() > 0 ? item?.latlng[0] ?? 0 : 0;
                            pais.Longitud = item?.latlng?.Count() > 0 ? item?.latlng[1] ?? 0 : 0;
                            pais.CodigoRegional = item.callingCodes[0];
                            pais.CodigoPais = item.alpha2Code;
                            await _paisRepository.Update(pais);
                    };



                }
                catch (Exception x)
                {
                    continue;
                }
            }
        }


    }
}
