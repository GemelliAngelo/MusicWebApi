using Microsoft.AspNetCore.Http.HttpResults;
using MusicWebApi.App.Models;

namespace MusicWebApi.App.Endpoints
{
    public static class SongEndpoints
    {

        private static readonly Song[] _songs = [new Song() { Title = "Hello", AlbumName = "25" }, new Song() { Title = "Goosebumps", AlbumName = "Birds in the Trap Sing McKnight" }, new Song() { Title = "Waka Waka", AlbumName = "Sale el sol" }];

        public static void MapSongEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("api/songs");

            endpoints.MapGet("/", Get);
            endpoints.MapGet("/search", Search);
        }

        static Song[] Get()
        {
            return _songs;
        }

        static Results<Ok<Song>, NotFound, ProblemHttpResult> Search(string name)
        {
            var result = _songs.FirstOrDefault(s => s.Title == name);
            return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
        }
    }
}
