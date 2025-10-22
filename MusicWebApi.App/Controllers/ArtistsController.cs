using Microsoft.AspNetCore.Mvc;
using MusicWebApi.App.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicWebApi.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        readonly Artist[] _artists = [new Artist() { Name = "Adele", Age = 37}, new Artist() { Name = "Travis Scott", Age = 34}, new Artist() { Name = "Shakira", Age = 48}];

        // GET: api/<AlbumsController>
        [HttpGet]
        public Artist[] Get()
        {
            return _artists;
        }

        // GET api/<AlbumsController>/5
        [HttpGet("{index:int}")]
        public Artist Get(int index)
        {
            return _artists[index];
        }

        // POST api/<AlbumsController>
        [HttpPost]
        public object Post([FromBody] Artist payload)
        {
            return new { success = true, payload };
        }

        // PUT api/<AlbumsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlbumsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
