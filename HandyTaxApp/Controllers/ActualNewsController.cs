using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HandyTaxApp.Controllers
{
    public class ActualNewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualNewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<ActualNews> ObjectActualNewsList = _unitOfWork.ActualNews.GetAll();
            return View(ObjectActualNewsList);
        }

        public IActionResult DetailsPage(int? Id)
        {
            ActualNews actualNews = _unitOfWork.ActualNews.GetFirstOrDefault(u => u.Id == Id);
            return View(actualNews);  
        }

        public IActionResult UpsertPage(int? Id)
        {
            if (ModelState.IsValid)
            {
                if (Id == 0 || Id == null)
                {
                    
                    ActualNews actualNews = new ActualNews();
                    
                    return View(actualNews);
                }
                else
                {
                    var ActualNewsFromDb = _unitOfWork.ActualNews.GetFirstOrDefault(u => u.Id == Id);
                    return View(ActualNewsFromDb);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ActualNews Object)
        {
            if (ModelState.IsValid)
            {
                DateTime TodayDate = DateTime.Now;
                Object.Date = TodayDate;

                if (Object.Id == 0)
                {                   
                    _unitOfWork.ActualNews.Add(Object);
                }
                else
                {
                    _unitOfWork.ActualNews.Update(Object);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletePage(int? Id)
        {
            ActualNews actualNews = _unitOfWork.ActualNews.GetFirstOrDefault(u => u.Id == Id);
            return View(actualNews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ActualNews Object)
        {
            _unitOfWork.ActualNews.Remove(Object);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
