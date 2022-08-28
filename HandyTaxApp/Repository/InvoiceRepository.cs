using HandyTaxApp.Data;
using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;

namespace HandyTaxApp.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private ApplicationDbContext _db;

        public InvoiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }  
        
        public void Update(Invoice Object)
        {
            _db.Invoices.Update(Object);
        }
    }
}
