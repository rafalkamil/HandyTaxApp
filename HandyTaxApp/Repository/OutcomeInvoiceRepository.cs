using HandyTaxApp.Data;
using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;

namespace HandyTaxApp.Repository
{
    public class OutcomeInvoiceRepository : Repository<OutcomeInvoice>, IOutcomeInvoiceRepository
    {
        private ApplicationDbContext _db;

        public OutcomeInvoiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }  
        
        public void Update(OutcomeInvoice Object)
        {
            _db.OutcomeInvoices.Update(Object);
        }
    }
}
