namespace MultimediaLibrary.Repositories
{
    using System;
    using Models;
    using Interfaces;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.SqlServer;

    /// <summary>
    /// Implementation of methods from IArtistRepository
    /// </summary>
    public class ArtistRepository : IArtistRepository
    {
        /// <summary>
        /// Store database context
        /// </summary>
        private readonly AppDbContext context;

        /// <summary>
        /// Constructor that creates database context
        /// </summary>
        public ArtistRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MultimediaLibraryTest;Trusted_Connection=True;")
                .Options;
            context = new AppDbContext(options);
        }

        /// <summary>
        /// Constructor that assigns existing database context
        /// </summary>
        /// <param name="_context"> Database context, requires AppDbContext object </param>
        public ArtistRepository(AppDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Get all Artists that consist in the database
        /// </summary>
        /// <returns> Method returns an array od Artists </returns>
        public Artist[] GetArtists()
        {
            var artists = context.Artists.ToArray();
            return artists;
        }

        /// <summary>
        /// Get Artist by its id
        /// </summary>
        /// <param name="id"> InId of wanted artist, require integer argument </param>
        /// <returns> Returns Artist object </returns>
        public Artist GetArtist(int id)
        {
            var artist = context.Artists.Find(id);
            return artist;
        }

        /// <summary>
        /// Get Artist by its name
        /// </summary>
        /// <param name="name"> Name of wanted artist, require string argument </param>
        /// <returns> Returns Artist object </returns>
        public Artist GetArtist(string name)
        {
            var artist = context.Artists.Where(x => x.Name == name).First();
            return artist;
        }

        /// <summary>
        /// Get all Artists names that consist in the database
        /// </summary>
        /// <returns> Returns an array of string with artists names in </returns>
        public string[] GetArtistNames()
        {
            var artists = GetArtists();
            int quantity = artists.Count();
            string[] names = new string[quantity];


            for (int i = 0; i < quantity; i++)
            {
                names[i] = artists[i].Name;
            }
            return names;
        }

        /// <summary>
        /// Create new Artist entity in database
        /// </summary>
        /// <param name="artist"> Artist object that we want create in database, requires Artist object </param>
        /// <returns> Returns id of created artist </returns>
        public int CreateArtist(Artist artist)
        {
            context.Artists.Add(artist);
            context.SaveChanges();
            return artist.ArtistId;
        }

        /// <summary>
        /// Update existing Artist entity
        /// </summary>
        /// <param name="id"> Id of an artist that we want to update, requires integer argument </param>
        /// <param name="artist"> New Artist object that consist of new data of existing artist, requires Artist object </param>
        public void UpdateArtist(int id, Artist artist)
        {
            var oldArtist = context.Artists.Find(id);
            oldArtist.Name = artist.Name;
            oldArtist.YoutubeAccountPath = artist.YoutubeAccountPath;
            context.SaveChanges();
        }

        /// <summary>
        /// Delete existing artist
        /// </summary>
        /// <param name="id"> Id of an artist that we want to delete, requires integer argument </param>
        public void DeleteArtist(int id)
        {
            var artist = context.Artists.Find(id);
            context.Artists.Remove(artist);
            context.SaveChanges();
        }

        /// <summary>
        /// Check if artist exist
        /// </summary>
        /// <param name="id"> Id of an artist that we want to check, requires integer argument </param>
        /// <returns> Returns true if artist exist, or false if doesn'n exist </returns>
        public bool ArtistExist(int id)
        {
            var exist = context.Artists.Any(x => x.ArtistId == id);
            return exist;
        }
    }
}
