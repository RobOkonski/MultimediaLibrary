using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace MultimediaLibrary
{
    using Models;
    public class AppDbContext : DbContext
    {
        public DbSet<Artist> Artists { set; get; }
        public DbSet<Track> Tracks { set; get; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
