using Microsoft.EntityFrameworkCore;

namespace crud_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public SuperHero SuperHeroes { get; set; }
    }
}
