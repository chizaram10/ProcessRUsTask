using Microsoft.EntityFrameworkCore;
using ProcessRUsTask.Entities;

namespace ProcessRUsTask.Infrastructure.Respositories
{
    public class FruitRepository : IFruitRepository
    {
        private readonly ProcessRUsTaskDbContext _context;

        public FruitRepository(ProcessRUsTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fruit>> GetAllAsync()
        {
            return await _context.Fruits.ToListAsync();
        }
    }
}
