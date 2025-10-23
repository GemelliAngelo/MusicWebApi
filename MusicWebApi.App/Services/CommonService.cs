using Microsoft.AspNetCore.Http.HttpResults;
using MusicWebApi.App.Models;
using System.Xml.Linq;

namespace MusicWebApi.App.Services
{
    public class CommonService()
    {
        public List<Artist> Artists { get; set; } = [new() { Name = "Adele", Age = 37 }, new() { Name = "Travis Scott", Age = 34 }, new() { Name = "Shakira", Age = 48 }];

        public List<Song> Songs { get; set; } = [new Song() { Title = "Hello", AlbumName = "25" }, new Song() { Title = "Goosebumps", AlbumName = "Birds in the Trap Sing McKnight" }, new Song() { Title = "Waka Waka", AlbumName = "Sale el sol" }];

        public List<Artist> GetArtists(string name = "")
        {
            if (string.IsNullOrEmpty(name)) return Artists;

            return [Artists.FirstOrDefault(a => a.Name == name)];
        }

        public List<Song> GetSongs(string title = "")
        {
            if (string.IsNullOrEmpty(title)) return Songs;

            return [Songs.FirstOrDefault(s => s.Title == title)];
        }

        public void AddArtists(Artist artist)
        {
            Artists.Add(artist);
        }

        public void UpdateArtist(string name, Artist newArtist)
        {
            var artist = Artists.FirstOrDefault(a => a.Name == name);
            if (artist != null)
            {
                artist.Name = newArtist.Name;
                artist.Age = newArtist.Age;
            }
        }

        public void DeleteArtist(string name)
        {
            var artist = Artists.FirstOrDefault(a => a.Name == name);
            if (artist != null) Artists.Remove(artist);
        }
    }
}
