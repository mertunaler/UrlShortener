using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Web.Models.Entity
{
    public class UrlDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MyInMemoryDatabase");
        }
        public DbSet<Url> Urls { get; set; }

        
    }
}
