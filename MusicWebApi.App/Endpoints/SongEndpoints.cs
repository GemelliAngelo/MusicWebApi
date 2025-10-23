using Microsoft.AspNetCore.Http.HttpResults;
using MusicWebApi.App.Models;
using MusicWebApi.App.Services;

namespace MusicWebApi.App.Endpoints
{
    public static class SongEndpoints
    {
        public static void MapSongEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("api/songs");

            endpoints.MapGet("/", Get);
            endpoints.MapGet("/search", Search);
        }

        static List<Song> Get(CommonService commonService)
        {
            return commonService.GetSongs();
        }

        static Results<Ok<Song>, NotFound, ProblemHttpResult> Search(CommonService commonService, string title)
        {
            var result = commonService.GetSongs(title).First();
            return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
        }
    }
}
