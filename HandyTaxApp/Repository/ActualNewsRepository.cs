using HandyTaxApp.Data;
using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;

namespace HandyTaxApp.Repository
{
    public class ActualNewsRepository : Repository<ActualNews>, IActualNewsRepository
    {
        private ApplicationDbContext _db;

        public ActualNewsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }  
        
        public void Update(ActualNews Object)
        {
            _db.ActualNews.Update(Object);
        }
    }
}
