using Microsoft.AspNetCore.Mvc;
using MusicWebApi.App.Models;
using MusicWebApi.App.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicWebApi.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly CommonService _commonService;

        public ArtistsController(CommonService commonService)
        {
            _commonService = commonService;
        }

        // GET: api/<AlbumsController>
        [HttpGet]
        public List<Artist> Get()
        {
            return _commonService.GetArtists();
        }

        // GET api/<AlbumsController>/5
        [HttpGet("{index:int}")]
        public List<Artist> Get(int index)
        {
            return _commonService.GetArtists(index);
        }

        // POST api/<AlbumsController>
        [HttpPost]
        public object Post([FromBody] Artist payload)
        {
            _commonService.AddArtists(payload);
            return new { success = true, payload };
        }

        // PUT api/<AlbumsController>/5
        [HttpPut("{index}")]
        public Artist Put(int index, [FromBody] Artist payload)
        {
            _commonService.UpdateArtist(index, payload);
            return _commonService.Artists[index];
        }

        // DELETE api/<AlbumsController>/5
        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            _commonService.DeleteArtist(index);
        }
    }
}
