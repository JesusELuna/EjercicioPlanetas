using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure
{
    public class PredictionDBContext : DbContext
    {
        public PredictionDBContext(DbContextOptions<PredictionDBContext> options)
    : base(options)
        {
        }

        public DbSet<Weather> Weathers { get; set; }
    }
}
