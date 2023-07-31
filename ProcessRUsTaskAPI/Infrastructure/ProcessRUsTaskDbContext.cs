using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcessRUsTask.Entities;

namespace ProcessRUsTask.Infrastructure
{
    public class ProcessRUsTaskDbContext : IdentityDbContext
    {
        public ProcessRUsTaskDbContext(DbContextOptions<ProcessRUsTaskDbContext> options) : base(options)
        {
            Fruits = Set<Fruit>();
        }

        public DbSet<Fruit> Fruits { get; set; }
    }
}
