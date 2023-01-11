using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandyTaxApp.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InvoiceController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;   
        }
        public IActionResult Index()
        {
            IEnumerable<Invoice> ObjectInvoiceList = _unitOfWork.Invoices.GetAll();
            return View(ObjectInvoiceList);
        }

        public IActionResult DetailsPage(int? Id)
        {
            Invoice invoice = _unitOfWork.Invoices.GetFirstOrDefault(u => u.Id == Id);
            return View(invoice);  
        }

        public IActionResult UpsertPage(int? Id)
        {
            if (ModelState.IsValid)
            {     
                if (Id == 0 || Id == null)
                {
                    
                    Invoice invoice = new Invoice();
                    
                    return View(invoice);
                }
                else
                {
                    var InvoiceFromDb = _unitOfWork.Invoices.GetFirstOrDefault(u => u.Id == Id);
                    return View(InvoiceFromDb);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Invoice Object, IFormFile imgFile)
        {

            if (ModelState.IsValid)
            {
                string wwwwRootPath = _webHostEnvironment.WebRootPath;

                if(imgFile != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    var UploadImage = Path.Combine(wwwwRootPath, @"costInvoiceImages");
                    var Extension = Path.GetExtension(imgFile.FileName);

                    if(Object.ImageURL != null)
                    {
                        var oldImagePath = Path.Combine(wwwwRootPath, Object.ImageURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }

                    using (var fileStreamImage = new FileStream(Path.Combine(UploadImage, FileName + Extension), FileMode.Create))
                    {
                        imgFile.CopyTo(fileStreamImage);
                    }                  

                    Object.ImageURL = @"\costInvoiceImages\" + FileName + Extension;
                }
                

                if (Object.Id == 0)
                {
                    _unitOfWork.Invoices.Add(Object);
                }
                else
                {
                    _unitOfWork.Invoices.Update(Object);
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletePage(int? Id)
        {
            Invoice invoice = _unitOfWork.Invoices.GetFirstOrDefault(u => u.Id == Id);
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Invoice Object, IFormFile imgFile)
        {
            string wwwwRootPath = _webHostEnvironment.WebRootPath;

            if (Object.ImageURL != null)
            {
                var oldImagePath = Path.Combine(wwwwRootPath, Object.ImageURL.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            _unitOfWork.Invoices.Remove(Object);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
