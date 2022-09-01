using HandyTaxApp.Models;

namespace HandyTaxApp.Repository.IRepository
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        void Update(BlogPost Object);
    }
}
