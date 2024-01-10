using Hotel.WebApp.Utils.CustomExceptions;
using Hotel.WebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApp.Controllers
{
    public class ErrorController : BaseController
    {
        public async Task<IActionResult> Handle()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error;

            if (exception != null)
            {
                if (exception is UnauthorizedException)
                {
                    await HttpContext.SignOutAsync();

                    TempData["Session"] = "La sesión ha expirado, por favor vuelve a iniciar sesión.";

                    return RedirectToAction("Login", "Usuario");
                }

                if (exception is NotFoundException)
                {
                    var notFoundException = exception as NotFoundException;

                    var viewModel = new NotFoundViewModel();

                    viewModel.Message = notFoundException.Message;

                    return View("NotFoundView", viewModel);
                }

                try
                {
                    System.IO.File.AppendAllText("C:/Hotel/log.txt", $"{DateTime.Now} | {exception.Message} | {exception.InnerException?.Message}" + Environment.NewLine);
                }
                catch (Exception ex)
                {

                }
            }

            var errorViewModel = new ErrorViewModel(exception.Message);

            return View("Error", errorViewModel);

        }
    }
}
