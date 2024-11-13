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
            ViewBag.ShowMap = false;
            return View();
        }

        public IActionResult Index()
        {
            ViewBag.ShowMap = true;
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.ShowMap = false;
            return View();
        }

        [HttpGet]
        public IActionResult Data(string name, int age)
        {
            ViewBag.ShowMap = true;
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
            ViewBag.ShowMap = true;
            return View();
        }

        // Mottar skjemaets data etter innsending
        [HttpPost]
        public IActionResult SubmitErrorReport(ErrorReport model)
        {
            ViewBag.ShowMap = true;
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
            ViewBag.ShowMap = false;
            return View();
        }

        // Håndterer innloggingsforespørselen
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            ViewBag.ShowMap = false;
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
            ViewBag.ShowMap = false;
            // Generer 10 ulike innmeldinger
            var reports = new List<ErrorReport>
            {
                new ErrorReport { Id = 1, Description = "Feil i kartdata", Location = "Oslo", DateReported = DateTime.Now },
                new ErrorReport { Id = 2, Description = "Manglende vei", Location = "Bergen", DateReported = DateTime.Now.AddDays(-1) },
                new ErrorReport { Id = 3, Description = "Feil adresse", Location = "Trondheim", DateReported = DateTime.Now.AddDays(-2) },
                new ErrorReport { Id = 4, Description = "Feil bygning", Location = "Stavanger", DateReported = DateTime.Now.AddDays(-3) },
                new ErrorReport { Id = 5, Description = "Manglende bygning", Location = "Kristiansand", DateReported = DateTime.Now.AddDays(-4) },
                new ErrorReport { Id = 6, Description = "Feil vei", Location = "Tromsø", DateReported = DateTime.Now.AddDays(-5) },
                new ErrorReport { Id = 7, Description = "Feil postnummer", Location = "Drammen", DateReported = DateTime.Now.AddDays(-6) },
                new ErrorReport { Id = 8, Description = "Feil kommune", Location = "Fredrikstad", DateReported = DateTime.Now.AddDays(-7) },
                new ErrorReport { Id = 9, Description = "Feil fylke", Location = "Sandnes", DateReported = DateTime.Now.AddDays(-8) },
                new ErrorReport { Id = 10, Description = "Feil land", Location = "Ålesund", DateReported = DateTime.Now.AddDays(-9) }
            };

            return View(reports);
        }

        // Ny handling for brukersiden
        public IActionResult UserReports()
        {
            ViewBag.ShowMap = false;
            // Generer 5 ulike innmeldinger for brukeren
            var userReports = new List<ErrorReport>
            {
                new ErrorReport { Id = 1, Description = "Feil i kartdata", Location = "Oslo", DateReported = DateTime.Now },
                new ErrorReport { Id = 2, Description = "Manglende vei", Location = "Bergen", DateReported = DateTime.Now.AddDays(-1) },
                new ErrorReport { Id = 3, Description = "Feil adresse", Location = "Trondheim", DateReported = DateTime.Now.AddDays(-2) },
                new ErrorReport { Id = 4, Description = "Feil bygning", Location = "Stavanger", DateReported = DateTime.Now.AddDays(-3) },
                new ErrorReport { Id = 5, Description = "Manglende bygning", Location = "Kristiansand", DateReported = DateTime.Now.AddDays(-4) }
            };

            return View(userReports);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.ShowMap = false;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}