using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HandyTaxApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Privacy_policy()
        {
            return View();
        }

        public IActionResult Agent_HMRC()
        {
            return View();
        }

        public IActionResult AML()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Cookies()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}