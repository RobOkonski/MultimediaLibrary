namespace MultimediaLibrary.Interfaces
{
    using Models;
    public interface ITrackRepository 
    {
        Track[] GetTracks();
        Track[] GetTracksThatContains(int artistId);
        Track GetTrack(int id);
        int CreateTrack(Track track);
        void UpdateTrack(int id, Track track);
        void DeleteTrack(int id);
        bool TrackExist(int id);
    }
}
