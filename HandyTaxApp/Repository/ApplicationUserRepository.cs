using HandyTaxApp.Data;
using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;

namespace HandyTaxApp.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }  
 
    }
}
