using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HandyTaxApp.Controllers
{
    public class OutcomeInvoiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OutcomeInvoiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult DetailsPage(int? Id)
        {
            OutcomeInvoice outcomeinvoice = _unitOfWork.OutcomeInvoices.GetFirstOrDefault(u => u.Id == Id);
            return View(outcomeinvoice);  
        }

        public IActionResult UpsertPage(int? Id)
        {
            if (ModelState.IsValid)
            {     
                if (Id == 0 || Id == null)
                {

                    OutcomeInvoice outcomeinvoice = new OutcomeInvoice();
                    
                    return View(outcomeinvoice);
                }
                else
                {
                    var outcomeInvoiceFromDb = _unitOfWork.OutcomeInvoices.GetFirstOrDefault(u => u.Id == Id);
                    return View(outcomeInvoiceFromDb);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(OutcomeInvoice Object)
        {

            if (ModelState.IsValid)
            {
                var totalAmount = Object.UnitPrice * Object.Quantity;

                Object.TotalAmount = totalAmount;
                Object.TotalAmountVAT = (int)(totalAmount * 1.23);
                
                if (Object.Id == 0)
                {
                    _unitOfWork.OutcomeInvoices.Add(Object);
                }
                else
                {
                    _unitOfWork.OutcomeInvoices.Update(Object);
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletePage(int? Id)
        {
            OutcomeInvoice outcomeinvoice = _unitOfWork.OutcomeInvoices.GetFirstOrDefault(u => u.Id == Id);
            return View(outcomeinvoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(OutcomeInvoice Object)
        {
            _unitOfWork.OutcomeInvoices.Remove(Object);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var outcomeinvoiceList = _unitOfWork.OutcomeInvoices.GetAll();
            return Json(new { data = outcomeinvoiceList });
        }
        #endregion
    }
}
