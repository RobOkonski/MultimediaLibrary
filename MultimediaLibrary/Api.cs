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

namespace MultimediaLibrary
{
    class Api
    {
        public async Task<SearchResult> FindID(string name, string typeToSearch)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBd-1CLlC-cxBSmFhthjPPzssOtELWNV0Q",       
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet ");
            searchListRequest.Q = name;  
            searchListRequest.Type = typeToSearch;
            searchListRequest.MaxResults = 5;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            List<SearchResult> SelectedResults = new List<SearchResult>();
            
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        var requestViewsCount = youtubeService.Videos.List("statistics ");
                        requestViewsCount.Id = searchResult.Id.VideoId;
                        var requestViewsResponse = await requestViewsCount.ExecuteAsync();
                        SelectedResults.Add(new SearchResult(searchResult.Snippet.Title, searchResult.Id.VideoId, requestViewsResponse.Items[0].Statistics.ViewCount));
                        break;

                    case "youtube#channel":
                        var requestSubsCount = youtubeService.Channels.List("statistics ");
                        requestSubsCount.Id = searchResult.Id.ChannelId;
                        var requestSubsResponse = await requestSubsCount.ExecuteAsync();
                        SelectedResults.Add(new SearchResult(searchResult.Snippet.Title, searchResult.Id.ChannelId, requestSubsResponse.Items[0].Statistics.SubscriberCount));
                        break;
                }
            }
            var query =
                        SelectedResults.Select(n => n)
                        .OrderByDescending(n => n.Count)
                        .FirstOrDefault();
            return query;
        }


        public class SearchResult
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public ulong? Count { get; set; }

            public SearchResult(string name, string id, ulong? count)
            {
                this.Name = name;
                this.ID = id;
                this.Count = count;
            }
        }        
    }
}
