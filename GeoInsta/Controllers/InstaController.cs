using GeoInsta.Enums;
using GeoInsta.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoInsta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstaController : ControllerBase
    {
        private readonly ILogger<InstaController> _logger;
        private readonly InstaService _instaService;
        public InstaController(ILogger<InstaController> logger, InstaService instaService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _instaService = instaService ?? throw new ArgumentNullException(nameof(instaService));
        }

        [HttpGet]
        [Route("SearchLocation")]
        public async Task<IActionResult> SearchLocation(string username, string password, string place)
        {
            await _instaService.Login(username, password);
            return Ok(await _instaService.SearchLocation(place));
        }

        [HttpGet]
        [Route("GetLocationFeeds")]
        public async Task<IActionResult> GetLocationFeeds(string username, string password, long locationId, InstaLocationTopOrRecent topOrRecent = InstaLocationTopOrRecent.Top)
        {
            await _instaService.Login(username, password);
            return Ok(await _instaService.GetLocationFeeds(locationId, topOrRecent));
        }
    }
}