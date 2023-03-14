namespace HandyTaxApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoices { get; }
        IOutcomeInvoiceRepository OutcomeInvoices { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
