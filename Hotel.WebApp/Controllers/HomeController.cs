using Hotel.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public HomeController()
        { 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}