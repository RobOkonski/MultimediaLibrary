namespace MultimediaLibrary.Interfaces
{
    using Models;
    public interface ITrackRepository 
    {
        Track[] GetTracks();
        Track GetTrack(int id);
        int CreateTrack(Track track);
        void UpdateTrack(int id, Track track);
        void DeleteTrack(int id);
        bool TrackExist(int id);
    }
}
