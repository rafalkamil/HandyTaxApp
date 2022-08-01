using HandyTaxApp.Models;

namespace HandyTaxApp.Repository.IRepository
{
    public interface IActualNewsRepository : IRepository<ActualNews>
    {
        void Update(ActualNews Object);
    }
}
