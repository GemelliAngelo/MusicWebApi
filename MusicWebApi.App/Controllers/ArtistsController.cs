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
        private readonly ILogger<ArtistsController> _logger;
        private readonly CommonService _commonService;

        public ArtistsController(ILogger<ArtistsController> logger, CommonService commonService)
        {
            _logger = logger;
            _commonService = commonService;
        }

        
        // GET api/<ArtistsController>/Artist
        [HttpGet()]
        public List<Artist> Get([FromQuery] string? name)
        {
            if (string.IsNullOrEmpty(name))
                return _commonService.GetArtists();

            return _commonService.GetArtists(name);
        }

        // POST api/<ArtistsController>
        [HttpPost]
        public void Post([FromBody] Artist payload)
        {
            _logger.LogInformation($"{payload.Name} added");
            _commonService.AddArtists(payload);
        }

        // PUT api/<ArtistsController>/My Artist
        [HttpPut()]
        public void Put([FromQuery]string name, [FromBody] Artist payload)
        {
            _logger.LogInformation($"{payload.Name} updated");
            _commonService.UpdateArtist(name, payload);
        }

        // DELETE api/<ArtistsController>/My Artist
        [HttpDelete()]
        public void Delete([FromQuery] string name)
        {
            _commonService.DeleteArtist(name);
        }
    }
}
