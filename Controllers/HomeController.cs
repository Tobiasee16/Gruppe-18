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

        // Forsiden av applikasjonen
        public IActionResult Home()
        {
            return View();
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
        
        // Viser skjemaet for å rapportere feil
        [HttpGet]
        public IActionResult ReportError()
        {
            return View();
        }

        // Mottar skjemaets data etter innsending
        [HttpPost]
        public IActionResult SubmitErrorReport(ErrorReport model)
        {
            if (ModelState.IsValid)
            {
                return View("ErrorReportConfirmation", model);
            }

            return View("ReportError");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
