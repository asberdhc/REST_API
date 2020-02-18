using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API.Controllers
{
    public class MyYTAPIController : ApiController
    {
        //GET api/MyYTAPI
        [HttpGet]
        public List<SearchResultDTO> GetResults (string keyword)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                //ApiKey = "AIzaSyAV7dZdpjsqH9K2IkJ0tlqHWklDay0qMW4",
                ApiKey = "AIzaSyBBEISZIIw4C-D-urwLzcUdBrvH1DX6UA4",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword; // Replace with your search term.
            searchListRequest.MaxResults = 10;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

            return searchListResponse.Items.Select(sr => new SearchResultDTO { VideoId = sr.Id.VideoId, Title = sr.Snippet.Title }).ToList();
        }
    }
}
