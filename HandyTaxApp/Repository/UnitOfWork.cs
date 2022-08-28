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

            ActualNews = new ActualNewsRepository(_db);
            BlogPosts = new BlogPostRepository(_db);
            Invoices = new InvoiceRepository(_db);
        }  
        
        public IActualNewsRepository ActualNews { get; private set; }
        public IBlogPostRepository BlogPosts { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
