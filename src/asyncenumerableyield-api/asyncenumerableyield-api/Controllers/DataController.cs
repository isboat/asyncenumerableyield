using Microsoft.AspNetCore.Mvc;

namespace asyncenumerableyield_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly IMovieCollectionService _movieCollectionService;

        public DataController(ILogger<DataController> logger, IMovieCollectionService movieCollectionService)
        {
            _logger = logger;
            _movieCollectionService = movieCollectionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shows = new List<string>();
            await foreach (var show in _movieCollectionService.GetTVShows())
            {
                shows.Add(show.Name);  
            }
            return new OkObjectResult(shows);
        }
    }
}