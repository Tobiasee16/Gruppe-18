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
        public IActionResult Data(string name, int age)
        {
            var model = new UserViewModel
            {
                Name = name,
                Age = age,
            };
            return View(model);
        }

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

        // Viser innloggingssiden
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Håndterer innloggingsforespørselen
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Implementer innloggingslogikk her, for eksempel autentisering mot en database
                // Hvis innlogging er vellykket, kan du omdirigere til en annen side, som forside eller dashboard
                return RedirectToAction("Index");
            }

            // Hvis modellen ikke er gyldig, vis innloggingsskjemaet igjen med valideringsfeil
            return View(model);
        }

        // Ny handling for admin-siden
        public IActionResult Admin()
        {
            // Hent innmeldinger fra en database eller en annen kilde
            var reports = new List<ErrorReport>
            {
                new ErrorReport { Id = 1, Description = "Feil i kartdata", Location = "Oslo", DateReported = DateTime.Now },
                new ErrorReport { Id = 2, Description = "Manglende vei", Location = "Bergen", DateReported = DateTime.Now.AddDays(-1) }
            };

            return View(reports);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}