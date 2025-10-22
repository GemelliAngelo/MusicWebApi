using Microsoft.AspNetCore.Http.HttpResults;
using MusicWebApi.App.Models;

namespace MusicWebApi.App.Endpoints
{
    public static class SongEndpoints
    {

        private static readonly Song[] _songs = [new Song() { Title = "Hello", ArtistName = "Adele" }, new Song() { Title = "Goosebumps", ArtistName = "Travis Scott" }, new Song() { Title = "Waka Waka", ArtistName = "Shakira" }];

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
