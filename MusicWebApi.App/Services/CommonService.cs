using MusicWebApi.App.Models;

namespace MusicWebApi.App.Services
{
    public class CommonService()
    {
        public List<Artist> Artists { get; set; } = [new() { Name = "Adele", Age = 37 }, new() { Name = "Travis Scott", Age = 34 }, new() { Name = "Shakira", Age = 48 }];

        public List<Artist> GetArtists(int index = default)
        {
            if (index != default) return [Artists[index]];

            return Artists;
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
