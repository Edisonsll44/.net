using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Soulsplit.Api.Aplicaciones.Servicios;
using System.Reflection;

namespace Soulsplit.Api.ServiciosDistribuidos.Helpers
{
    public class LoggerHelper : IActionFilter
    {
        private string body = string.Empty;
        private readonly ILogger<LoggerHelper> _logger;
        private readonly IMensajeService _mensajeService;

        public LoggerHelper(ILogger<LoggerHelper> logger, IMensajeService mensajeService)
        {
            _logger = logger;
            _mensajeService = mensajeService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is not null)
            {
                if (context.Exception.Source.Equals("Microsoft.EntityFrameworkCore.Relational"))
                {
                    string mensaje = $"Source:{context?.Exception?.Source} \n";
                    _logger.LogWarning($"Metodo:{ MethodBase.GetCurrentMethod()} Recurso:{context.ActionDescriptor.AttributeRouteInfo.Template} Base de datos: {context.Exception.InnerException.Message}");
                    _mensajeService.EnviarLogError(body, mensaje, context.Exception, context?.HttpContext?.Request);
                }
                if (context.Exception.Source.Equals("Soulsplit.Api.Validaciones"))
                {
                    _logger.LogError(context.Exception.Message);
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            body = JsonConvert.SerializeObject(context.ActionArguments);
        }
    }
}
