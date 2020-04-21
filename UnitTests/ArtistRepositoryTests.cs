namespace UnitTests
{
    using System;
    using Xunit;
    using MultimediaLibrary;
    using Microsoft.EntityFrameworkCore;
    using MultimediaLibrary.Interfaces;
    using MultimediaLibrary.Repositories;
    using MultimediaLibrary.Models;

    public class ArtistRepositoryTests
    {
        [Fact]
        public void ShouldReturnAllArtists()
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.GetArtists();

            Assert.Equal(3,result.Length);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ShouldReturnProperArtistById(int id)
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.GetArtist(id);

            Assert.Equal(id, result.ArtistId);
        }

        [Theory]
        [InlineData("aaaa")]
        [InlineData("bbbb")]
        [InlineData("cccc")]
        public void ShouldReturnProperArtistByName(string name)
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.GetArtist(name);

            Assert.Equal(name, result.Name);
        }

        [Fact]
        public void ShouldGetAllArtistsNames()
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.GetArtistNames();

            Assert.Equal(3, result.Length);
            Assert.Equal("aaaa", result[0]);
            Assert.Equal("bbbb", result[1]);
            Assert.Equal("cccc", result[2]);
        }

        [Fact]
        public void ShouldCreateArtist()
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());

            var result = query.CreateArtist(new Artist {Name = "dddd", YoutubeAccountPath = "xyz.com" });
            Assert.Equal(1, result);
            Assert.Equal("dddd", query.GetArtist(result).Name);
            Assert.Equal("xyz.com", query.GetArtist(result).YoutubeAccountPath);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ShouldUpdateArtist(int id)
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            query.UpdateArtist(id, new Artist { Name = "dddd", YoutubeAccountPath="xyz.com"});

            var result = query.GetArtist(id);
            Assert.Equal("dddd", result.Name);
            Assert.Equal("xyz.com",result.YoutubeAccountPath);
        }

        [Fact]
        public void ShouldDeleteArtist()
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            Assert.Equal(3, query.GetArtists().Length);

            query.DeleteArtist(2);

            Assert.Equal(2, query.GetArtists().Length);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldCheckIfExist(int id)
        {
            var (context, query) = Initialize(Guid.NewGuid().ToString());
            Seed(context);

            var result = query.ArtistExist(id);

            if (id > 3) Assert.False(result);
            else Assert.True(result);            
        }

        private void Seed(AppDbContext context)
        {
            var artists = new[]
            {
                new Artist {Name = "aaaa"},
                new Artist {Name = "bbbb"},
                new Artist {Name = "cccc"},
            };
            context.Artists.AddRange(artists);
            context.SaveChanges();
        }

        private (AppDbContext, IArtistRepository) Initialize(string DbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: DbName)
                .Options;
            var context = new AppDbContext(options);

            var query = new ArtistRepository(context);

            return (context, query);
        }
    }
}
