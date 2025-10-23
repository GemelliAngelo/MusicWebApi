using Microsoft.AspNetCore.Http.HttpResults;
using MusicWebApi.App.Models;
using MusicWebApi.App.Services;

namespace MusicWebApi.App.Endpoints
{
    public static class SongEndpoints
    {

        private static readonly CommonService _commonService = new CommonService();

        public static void MapSongEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("api/songs");

            endpoints.MapGet("/", Get);
            endpoints.MapGet("/search", Search);
        }

        static List<Song> Get()
        {
            return _commonService.GetSongs();
        }

        static Results<Ok<Song>, NotFound, ProblemHttpResult> Search(string title)
        {
            var result = _commonService.GetSongs().First();
            return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
        }
    }
}
