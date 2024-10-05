using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Data(string name, int age)
        {
            var model = new UserViewModel
            {
                Name = name,
                Age = age,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitData(string userInput)
        {
            // Behandle dataene her
            // Lagre dataene i databasen eller sesjonen, eller send dem til en annen nettside

            // Du kan omdirigere til en annen handling eller returnere en view
            return RedirectToAction("DisplayData", new { data = userInput });
        }

        public IActionResult DisplayData(string data)
        {
            ViewBag.UserData = data;  // Lagre dataene i ViewBag eller en modell
            return View();  // Returner en view som viser dataene
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Map()
        {
            return View();
        }

    }
}
