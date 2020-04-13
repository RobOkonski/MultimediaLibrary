using Microsoft.EntityFrameworkCore;

namespace MultimediaLibrary
{
    class AppDbContext : DbContext
    {
        DbSet<Artist> Artists { set; get; }
        DbSet<Track> Tracks { set; get; }
    }
}
