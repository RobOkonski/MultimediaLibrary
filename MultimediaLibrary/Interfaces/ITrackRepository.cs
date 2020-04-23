namespace MultimediaLibrary.Interfaces
{
    using Models;

    /// <summary>
    /// Give interface for Track table 
    /// </summary>
    /// <remarks>
    /// Access to the database Track table is only allowed by using this methods
    /// </remarks>
    public interface ITrackRepository 
    {
        /// <summary>
        /// Get all Tracks from database
        /// </summary>
        /// <returns> Returns an array of tracks </returns>
        Track[] GetTracks();

        /// <summary>
        /// Get a Tracks that belongs to indicated artist
        /// </summary>
        /// <param name="artistId"> Id of an artist whose track we want, requires integer argument </param>
        /// <returns> Returns an array of Tracks </returns>
        Track[] GetTracksThatContains(int artistId);

        /// <summary>
        /// Get a Track by its id
        /// </summary>
        /// <param name="id"> Id of wanted Track, requires integer argument </param>
        /// <returns> Returns Track object </returns>
        Track GetTrack(int id);

        /// <summary>
        /// Create new Track entity in database
        /// </summary>
        /// <param name="track"> Track object that we wat to create, requires Track object </param>
        /// <returns> Returns id of created track </returns>
        int CreateTrack(Track track);

        /// <summary>
        /// Update an existing track
        /// </summary>
        /// <param name="id"> Id of a track that we want to update, requires integer argument </param>
        /// <param name="track"> New track object that consist of new track data, requires Track object </param>
        void UpdateTrack(int id, Track track);

        /// <summary>
        /// Delete existing track
        /// </summary>
        /// <param name="id"> Id of a track that we want to delete, requires integer argument </param>
        void DeleteTrack(int id);

        /// <summary>
        /// Check if track exist
        /// </summary>
        /// <param name="id"> Id of a track that we want to check, requires integer argument </param>
        /// <returns> Returns true if track exist, or false if not </returns>
        bool TrackExist(int id);
    }
}
