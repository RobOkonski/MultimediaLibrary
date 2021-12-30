namespace MultimediaLibrary
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Reflection;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Google.Apis.Upload;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using Google.Apis.YouTube.v3;
    using Google.Apis.Auth.OAuth2;

    /// <summary>
    /// Implementations of API Interface.
    /// </summary>
    class Api
    {
        /// <summary>
        /// Find item by keyword 
        /// </summary>
        /// <param name="name"> Name of channel/video to search </param>
        /// <param name="typeToSearch"> Type of object to search (channel/video) </param>
        /// <returns> Returns SearchApiResult, which contains: Name, ID, Count </returns>
        public SearchApiResult FindID(string name, string typeToSearch)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDFpCcN1LtmocyfJpO67VSKZqCECaCmYyo",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet ");
            searchListRequest.Q = name;
            searchListRequest.MaxResults = 20;
            searchListRequest.Type = typeToSearch;            

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            List<SearchApiResult> SelectedResults = new List<SearchApiResult>();

            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        var requestViewsCount = youtubeService.Videos.List("statistics ");
                        requestViewsCount.Id = searchResult.Id.VideoId;
                        var requestViewsResponse = requestViewsCount.Execute();
                        SelectedResults.Add(new SearchApiResult(searchResult.Snippet.Title, searchResult.Id.VideoId, requestViewsResponse.Items[0].Statistics.ViewCount));
                        break;

                    case "youtube#channel":
                        var requestSubsCount = youtubeService.Channels.List("statistics ");
                        requestSubsCount.Id = searchResult.Id.ChannelId;
                        var requestSubsResponse = requestSubsCount.Execute();
                        SelectedResults.Add(new SearchApiResult(searchResult.Snippet.Title, searchResult.Id.ChannelId, requestSubsResponse.Items[0].Statistics.SubscriberCount));
                        break;
                }
            }
            var query =
                        SelectedResults.Select(n => n)
                        .OrderByDescending(n => n.Count)
                        .FirstOrDefault();
            return query;
        }

        /// <summary>
        /// Store base parametres of object
        /// </summary>
        public class SearchApiResult
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public ulong? Count { get; set; }

            public SearchApiResult(string name, string id, ulong? count)
            {
                this.Name = name;
                this.ID = id;
                this.Count = count;
            }
        }
    }
}
