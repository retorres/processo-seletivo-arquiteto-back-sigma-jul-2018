using GP.CommandSide.Application.Core;
using GP.Api.AspNet.Models;
using GP.CommandSide.Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace GP.Api.AspNet.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public CustomExceptionFilter(IHostingEnvironment hostingEnvironment, ILogger<CustomExceptionFilter> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            BaseModelResponse model = null;
            switch (context.Exception)
            {
                case CommandValidationException cve:
                    model = BaseModelResponse.BadRequest(cve.Erros);
                    break;
                case DomainException domainE:
                    model = BaseModelResponse.BadRequest(domainE.Message);
                    break;
                default:
                    model = BaseModelResponse.InternalServerError(context.Exception.Message);
                    break;
            }

            context.Result = new ObjectResult(model)
            {
                StatusCode = model.StatusCode,
                DeclaredType = typeof(BaseModelResponse)
            };
        }
    }
}