using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hotel.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected string CurrentToken => User.FindFirstValue("Token");
        protected int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
