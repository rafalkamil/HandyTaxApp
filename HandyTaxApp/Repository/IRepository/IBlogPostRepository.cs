using HandyTaxApp.Models;

namespace HandyTaxApp.Repository.IRepository
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        void Update(Invoice Object);
    }
}
