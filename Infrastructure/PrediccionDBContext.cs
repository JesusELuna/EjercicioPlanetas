using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure
{
    public class PrediccionDBContext : DbContext
    {
        public PrediccionDBContext(DbContextOptions<PrediccionDBContext> options)
    : base(options)
        {
        }

        public DbSet<Clima> Climas { get; set; }
    }
}
