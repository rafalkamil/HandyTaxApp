namespace HandyTaxApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IActualNewsRepository ActualNews { get; }

        void Save();
    }
}
