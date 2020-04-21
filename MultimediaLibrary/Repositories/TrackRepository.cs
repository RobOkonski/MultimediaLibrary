namespace MultimediaLibrary.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Interfaces;
    using System.Linq;

    public class TrackRepository : ITrackRepository
    { 
        private readonly AppDbContext context;

        public TrackRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseLazyLoadingProxies()
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MultimediaLibrary;Trusted_Connection=True;")
               .Options;
            context = new AppDbContext(options);
        }

        public TrackRepository(AppDbContext _context)
        {
            context = _context; 
        }

        public Track[] GetTracks()
        {
            var tracks = context.Tracks.ToArray();
            return tracks;
        }

        public Track[] GetTracksThatContains(int artistId)
        {
            var tracks = context.Tracks.Where(x => x.ArtistId == artistId).ToArray();
            return tracks;
        }

        public Track GetTrack(int id)
        {
            var track = context.Tracks.Find(id);
            return track;
        }

        public int CreateTrack(Track track)
        {
            context.Tracks.Add(track);
            context.SaveChanges();
            return track.TrackId;
        }

        public void UpdateTrack(int id, Track track)
        {
            var oldtrack = context.Tracks.Find(id);
            oldtrack.Name = track.Name;
            oldtrack.ArtistId = track.ArtistId;
            oldtrack.YoutubePath = track.YoutubePath;
            context.SaveChanges();
        }

        public void DeleteTrack(int id)
        {
            var track = context.Tracks.Find(id);
            context.Tracks.Remove(track);
            context.SaveChanges();
        }

        public bool TrackExist(int id)
        {
            var exist = context.Tracks.Any(x => x.TrackId == id);
            return exist;
        }
    }
}
