using HandyTaxApp.Data;
using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;

namespace HandyTaxApp.Repository
{
    public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        private ApplicationDbContext _db;

        public BlogPostRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }  
        
        public void Update(BlogPost Object)
        {
            _db.BlogPosts.Update(Object);
        }
    }
}
