namespace MultimediaLibrary.Repositories
{
    using System;
    using Models;
    using Interfaces;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.SqlServer;

    public class ArtistRepository : IArtistRepository
    {
        private readonly AppDbContext context;

        public ArtistRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MultimediaLibrary;Trusted_Connection=True;")
                .Options;
            context = new AppDbContext(options);
        }

        public ArtistRepository(AppDbContext _context)
        {
            context = _context;
        }

        public Artist[] GetArtists()
        {
            var artists = context.Artists.ToArray();
            return artists;
        }

        public Artist GetArtist(int id)
        {
            var artist = context.Artists.Find(id);
            return artist;
        }

        public Artist GetArtist(string name)
        {
            var artist = context.Artists.Where(x => x.Name == name).First();
            return artist;
        }

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

        public int CreateArtist(Artist artist)
        {
            context.Artists.Add(artist);
            context.SaveChanges();
            return artist.ArtistId;
        }

        public void UpdateArtist(int id, Artist artist)
        {
            var oldArtist = context.Artists.Find(id);
            oldArtist.Name = artist.Name;
            oldArtist.YoutubeAccountPath = artist.YoutubeAccountPath;
            context.SaveChanges();
        }

        public void DeleteArtist(int id)
        {
            var artist = context.Artists.Find(id);
            context.Artists.Remove(artist);
            context.SaveChanges();
        }

        public bool ArtistExist(int id)
        {
            var exist = context.Artists.Any(x => x.ArtistId == id);
            return exist;
        }
    }
}
