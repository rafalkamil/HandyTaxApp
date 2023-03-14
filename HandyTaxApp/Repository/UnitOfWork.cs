using HandyTaxApp.Data;
using HandyTaxApp.Models;
using HandyTaxApp.Repository.IRepository;

namespace HandyTaxApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Invoices = new InvoiceRepository(_db);
            OutcomeInvoices = new OutcomeInvoiceRepository(_db);
        }  
        
        public IInvoiceRepository Invoices { get; private set; }
        public IOutcomeInvoiceRepository OutcomeInvoices { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
