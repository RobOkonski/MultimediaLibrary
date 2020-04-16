namespace MultimediaLibrary.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Interfaces;
    using System.Linq;

    public class ArtistRepository : IArtistRepository
    {
        private readonly AppDbContext context;

        public ArtistRepository(/*AppDbContext _context*/)
        {
            //context = _context;
            context = new AppDbContext();
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

        public int CreateArtist(Artist artist)
        {
            context.Artists.Add(artist);
            context.SaveChanges();
            return artist.Id;
        }

        public void UpdateArtist(int id, Artist artist)
        {
            var oldArtist = context.Artists.Find(id);
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
            var exist = context.Artists.Any(x => x.Id == id);
            return exist;
        }
    }
}
