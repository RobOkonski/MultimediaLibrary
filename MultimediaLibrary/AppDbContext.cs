using Microsoft.EntityFrameworkCore;

namespace MultimediaLibrary
{
    class AppDbContext : DbContext
    {
        /*public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }*/
        public DbSet<Artist> Artists { set; get; }
        public DbSet<Track> Tracks { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0QE7KCN;Initial Catalog=MultimediaLibrary;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
