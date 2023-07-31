using ProcessRUsTask.Entities;

namespace ProcessRUsTask.Infrastructure.Respositories
{
    public interface IFruitRepository
    {
        Task<IEnumerable<Fruit>> GetAllAsync();
    }
}