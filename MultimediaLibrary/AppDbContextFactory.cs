using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MultimediaLibrary
{
    /// <summary>
    /// AppDbContextFactory class
    /// </summary>
    /// <remarks>
    /// Used with migrations
    /// </remarks>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <summary>
        /// Create AppDbContext for migrations
        /// </summary>
        /// <param name="args"></param>
        /// <returns> Returns AppDbContext object </returns>
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(@"Server=tcp:psk-projekt.database.windows.net,1433;Initial Catalog=psk-projekt;Persist Security Info=False;User ID=robert;Password=#EDC4rfv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}