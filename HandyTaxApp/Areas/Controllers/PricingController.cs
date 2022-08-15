using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HandyTaxApp.Controllers
{
    public class PricingController : Controller
    {

        public PricingController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SelfEmployedPage()
        {
            return View();
        }
        public IActionResult LTDPage()
        {
            return View();
        }
        public IActionResult VirtualOffice()
        {
            return View();
        }

    }
}
