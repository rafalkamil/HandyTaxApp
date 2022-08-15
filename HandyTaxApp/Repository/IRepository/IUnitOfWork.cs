namespace HandyTaxApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IActualNewsRepository ActualNews { get; }
        IBlogPostRepository BlogPosts { get; }

        void Save();
    }
}
