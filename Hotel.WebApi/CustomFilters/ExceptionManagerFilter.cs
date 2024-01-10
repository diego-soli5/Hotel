using Hotel.BusinessLogic.CustomExceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Hotel.WebApi.Models;

namespace Hotel.WebApi.CustomFilters
{
    public class ExceptionManagerFilter : Controller, IExceptionFilter
    {
        public ExceptionManagerFilter()
        {
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is BusinessException)
            {
                var excNegocio = exception as BusinessException;

                var respuesta = new Response(exception.Message);

                if (excNegocio.StatusCode.HasValue)
                {
                    context.Result = StatusCode(excNegocio.StatusCode.Value, respuesta);
                }
                else
                {
                    context.Result = BadRequest(respuesta);
                }

            }
            else
            {
                context.Result = StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = exception.Message });
            }
        }
    }
}
