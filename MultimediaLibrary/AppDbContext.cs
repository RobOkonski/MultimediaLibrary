using Microsoft.EntityFrameworkCore;

namespace MultimediaLibrary
{
    using Models;
    class AppDbContext : DbContext
    {
        public DbSet<Artist> Artists { set; get; }
        public DbSet<Track> Tracks { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MultimediaLibrary;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
