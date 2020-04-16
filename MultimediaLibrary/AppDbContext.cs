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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0QE7KCN;Initial Catalog=MultimediaLibrary;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
