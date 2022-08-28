using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HandyTaxApp.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogPostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<BlogPost> ObjectBlogPostList = _unitOfWork.BlogPosts.GetAll();
            return View(ObjectBlogPostList);
        }

        public IActionResult DetailsPage(int? Id)
        {
            BlogPost blogPost = _unitOfWork.BlogPosts.GetFirstOrDefault(u => u.Id == Id);
            return View(blogPost);
        }

        public IActionResult UpsertPage(int? Id)
        {
            if (ModelState.IsValid)
            {
                if (Id == 0 || Id == null)
                {

                    BlogPost blogPost = new BlogPost();

                    return View(blogPost);
                }
                else
                {
                    var BlogPostFromDb = _unitOfWork.BlogPosts.GetFirstOrDefault(u => u.Id == Id);
                    return View(BlogPostFromDb);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BlogPost Object)
        {
            if (ModelState.IsValid)
            {
                DateTime TodayDate = DateTime.Now;
                Object.Date = TodayDate;

                if (Object.Id == 0)
                {
                    _unitOfWork.BlogPosts.Add(Object);
                }
                else
                {
                    _unitOfWork.BlogPosts.Update(Object);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletePage(int? Id)
        {
            BlogPost blogPost = _unitOfWork.BlogPosts.GetFirstOrDefault(u => u.Id == Id);
            return View(blogPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BlogPost Object)
        {
            _unitOfWork.BlogPosts.Remove(Object);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
