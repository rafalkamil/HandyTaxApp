namespace HandyTaxApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoices { get; }
        IOutcomeInvoiceRepository OutcomeInvoices { get; }
        void Save();
    }
}
