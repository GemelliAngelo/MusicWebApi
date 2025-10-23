using MusicWebApi.App.Models;

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

        public void UpdateArtist(int index, Artist artist)
        {
            Artists[index] = artist;
        }

        public void DeleteArtist(int index)
        {
            Artists.RemoveAt(index);
        }
    }
}
