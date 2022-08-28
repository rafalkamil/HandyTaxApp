using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HandyTaxApp.Controllers
{
    public class ServicesController : Controller
    {

        public ServicesController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LTDPage()
        {
            return View();
        }

        public IActionResult SelfEmployedPage()
        {
            return View();
        }

        public IActionResult OtherPage()
        {
            return View();
        }

        public IActionResult NewCompanyPage()
        {
            return View();
        }
    }
}
