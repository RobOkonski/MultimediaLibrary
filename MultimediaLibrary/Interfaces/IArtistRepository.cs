namespace MultimediaLibrary.Interfaces
{
    using Models;
    public interface IArtistRepository 
    {
        Artist[] GetArtists();
        Artist GetArtist(int id);
        int CreateArtist(Artist artist);
        void UpdateArtist(int id, Artist artist);
        void DeleteArtist(int id);
        bool ArtistExist(int id);
    }
}
