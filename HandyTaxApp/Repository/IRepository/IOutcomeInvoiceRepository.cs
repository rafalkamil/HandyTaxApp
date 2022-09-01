using HandyTaxApp.Models;

namespace HandyTaxApp.Repository.IRepository
{
    public interface IOutcomeInvoiceRepository : IRepository<OutcomeInvoice>
    {
        void Update(OutcomeInvoice Object);
    }
}
