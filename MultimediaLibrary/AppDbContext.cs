using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace MultimediaLibrary
{
    using Models;

    /// <summary>
    /// Provides database service
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Create table of artists
        /// </summary>
        public DbSet<Artist> Artists { set; get; }

        /// <summary>
        /// Create table of tracks
        /// </summary>
        public DbSet<Track> Tracks { set; get; }

        /// <summary>
        /// Constructor of database 
        /// </summary>
        /// <param name="options"> Database options, requires DbContextOptions of AppDbContext object </param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
