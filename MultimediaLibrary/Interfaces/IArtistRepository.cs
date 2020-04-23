namespace MultimediaLibrary.Interfaces
{
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// Give interface for Artist table 
    /// </summary>
    /// <remarks>
    /// Access to the database Artist table is only allowed by using this methods
    /// </remarks>
    public interface IArtistRepository 
    {
        /// <summary>
        /// Get all Artists that consist in the database
        /// </summary>
        /// <returns> Method returns an array od Artists </returns>
        Artist[] GetArtists();

        /// <summary>
        /// Get Artist by its id
        /// </summary>
        /// <param name="id"> InId of wanted artist, require integer argument </param>
        /// <returns> Returns Artist object </returns>
        Artist GetArtist(int id);

        /// <summary>
        /// Get Artist by its name
        /// </summary>
        /// <param name="name"> Name of wanted artist, require string argument </param>
        /// <returns> Returns Artist object </returns>
        Artist GetArtist(string name);

        /// <summary>
        /// Get all Artists names that consist in the database
        /// </summary>
        /// <returns> Returns an array of string with artists names in </returns>
        string[] GetArtistNames();

        /// <summary>
        /// Create new Artist entity in database
        /// </summary>
        /// <param name="artist"> Artist object that we want create in database, requires Artist object </param>
        /// <returns> Returns id of created artist </returns>
        int CreateArtist(Artist artist);

        /// <summary>
        /// Update existing Artist entity
        /// </summary>
        /// <param name="id"> Id of an artist that we want to update, requires integer argument </param>
        /// <param name="artist"> New Artist object that consist of new data of existing artist, requires Artist object </param>
        void UpdateArtist(int id, Artist artist);

        /// <summary>
        /// Delete existing artist
        /// </summary>
        /// <param name="id"> Id of an artist that we want to delete, requires integer argument </param>
        void DeleteArtist(int id);

        /// <summary>
        /// Check if artist exist
        /// </summary>
        /// <param name="id"> Id of an artist that we want to check, requires integer argument </param>
        /// <returns> Returns true if artist exist, or false if doesn'n exist </returns>
        bool ArtistExist(int id);
    }
}
