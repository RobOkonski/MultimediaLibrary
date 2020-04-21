namespace UnitTests
{
    using System;
    using Xunit;
    using MultimediaLibrary;
    using Microsoft.EntityFrameworkCore;
    using MultimediaLibrary.Interfaces;
    using MultimediaLibrary.Repositories;
    using MultimediaLibrary.Models;

    public class TrackRepositoryTests
    {
        [Fact]
        public void ShouldReturnAllTracks()
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.GetTracks();

            Assert.Equal(3, result.Length);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ShouldReturnAllArtistsTracks(int artistId)
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.GetTracksThatContains(artistId);
            if (artistId == 1) Assert.Equal(2, result.Length);
            else Assert.Single(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ShouldReturnProperTrackById(int id)
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.GetTrack(id);
            Assert.Equal(id, result.TrackId);
        }

        [Fact]
        public void ShouldCreateTrack()
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);
            int quantity = query.GetTracks().Length;
            Track track = new Track { Name = "song4", ArtistId = 1 };

            var result = query.CreateTrack(track);
            Assert.Equal("song4", query.GetTrack(result).Name);
            Assert.Equal(1, query.GetTrack(result).ArtistId);
            Assert.Equal(quantity+1, query.GetTracks().Length);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ShouldUpdateTrack(int id)
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);
            Track newTrack = new Track { Name = "song4", ArtistId = 1, YoutubePath = "song4.com" };

            query.UpdateTrack(id, newTrack);
            var result = query.GetTrack(id);
            Assert.Equal("song4", result.Name);
            Assert.Equal("song4.com", result.YoutubePath);
            Assert.Equal(1,result.ArtistId);
            if (id == 3) Assert.Empty(query.GetTracksThatContains(2));
        }

        [Fact]
        public void ShouldDeleteTrack()
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);
            int quantity = query.GetTracks().Length;

            query.DeleteTrack(2);
            Assert.Equal(quantity-1, query.GetTracks().Length);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldCheckIfTrackExist(int id)
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.TrackExist(id);
            if (id > 3) Assert.False(result);
            else Assert.True(result);
        }

        private void Seed(AppDbContext context)
        {
            var artists = new[]
            {
                new Artist {Name = "aaaa"},
                new Artist {Name = "bbbb"},
            };
            context.Artists.AddRange(artists);
            var tracks = new[]
            {
                new Track {Name = "song1", ArtistId = 1},
                new Track {Name = "song2", ArtistId = 1},
                new Track {Name = "song3", ArtistId = 2},
            };
            context.Tracks.AddRange(tracks);
            context.SaveChanges();
        }

        private (AppDbContext, ITrackRepository) Initialize(string DbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: DbName)
                .Options;
            var context = new AppDbContext(options);

            var query = new TrackRepository(context);

            return (context, query);
        }
    }
}
