namespace MultimediaLibrary.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Interfaces;
    using System.Linq;

    /// <summary>
    /// Implenetations of methods from ITrackRepositoty.
    /// </summary>
    public class TrackRepository : ITrackRepository
    { 
        /// <summary>
        /// Store database context
        /// </summary>
        private readonly AppDbContext context;

        /// <summary>
        /// Constructor that creates database context
        /// </summary>
        public TrackRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseLazyLoadingProxies()
               .UseSqlServer(@"Server=tcp:psk-projekt.database.windows.net,1433;Initial Catalog=psk-projekt;Persist Security Info=False;User ID=robert;Password=#EDC4rfv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
               .Options;
            context = new AppDbContext(options);
        }

        /// <summary>
        /// Constructor that assigns existing database context
        /// </summary>
        /// <param name="_context"> Database context, requires AppDbContext object </param>
        public TrackRepository(AppDbContext _context)
        {
            context = _context; 
        }

        /// <summary>
        /// Get all Tracks from database
        /// </summary>
        /// <returns> Returns an array of tracks </returns>
        public Track[] GetTracks()
        {
            var tracks = context.Tracks.ToArray();
            return tracks;
        }

        /// <summary>
        /// Get a Tracks that belongs to indicated artist
        /// </summary>
        /// <param name="artistId"> Id of an artist whose track we want, requires integer argument </param>
        /// <returns> Returns an array of Tracks </returns>
        public Track[] GetTracksThatContains(int artistId)
        {
            var tracks = context.Tracks.Where(x => x.ArtistId == artistId).ToArray();
            return tracks;
        }

        /// <summary>
        /// Get a Track by its id
        /// </summary>
        /// <param name="id"> Id of wanted Track, requires integer argument </param>
        /// <returns> Returns Track object </returns>
        public Track GetTrack(int id)
        {
            var track = context.Tracks.Find(id);
            return track;
        }

        /// <summary>
        /// Create new Track entity in database
        /// </summary>
        /// <param name="track"> Track object that we wat to create, requires Track object </param>
        /// <returns> Returns id of created track </returns>
        public int CreateTrack(Track track)
        {
            context.Tracks.Add(track);
            context.SaveChanges();
            return track.TrackId;
        }

        /// <summary>
        /// Update an existing track
        /// </summary>
        /// <param name="id"> Id of a track that we want to update, requires integer argument </param>
        /// <param name="track"> New track object that consist of new track data, requires Track object </param>
        public void UpdateTrack(int id, Track track)
        {
            var oldtrack = context.Tracks.Find(id);
            oldtrack.Name = track.Name;
            oldtrack.ArtistId = track.ArtistId;
            oldtrack.YoutubePath = track.YoutubePath;
            context.SaveChanges();
        }

        /// <summary>
        /// Delete existing track
        /// </summary>
        /// <param name="id"> Id of a track that we want to delete, requires integer argument </param>
        public void DeleteTrack(int id)
        {
            var track = context.Tracks.Find(id);
            context.Tracks.Remove(track);
            context.SaveChanges();
        }

        /// <summary>
        /// Check if track exist
        /// </summary>
        /// <param name="id"> Id of a track that we want to check, requires integer argument </param>
        /// <returns> Returns true if track exist, or false if not </returns>
        public bool TrackExist(int id)
        {
            var exist = context.Tracks.Any(x => x.TrackId == id);
            return exist;
        }
    }
}
