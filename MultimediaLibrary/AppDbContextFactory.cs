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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MultimediaLibraryTest;Trusted_Connection=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}