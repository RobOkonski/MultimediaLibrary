namespace MultimediaLibrary.Interfaces
{
    using Models;
    public interface IArtistRepository 
    {
        Artist[] GetArtists();
        Artist GetArtist(int id);
        Artist GetArtist(string name);
        string[] GetArtistNames();
        int CreateArtist(Artist artist);
        void UpdateArtist(int id, Artist artist);
        void DeleteArtist(int id);
        bool ArtistExist(int id);
    }
}
