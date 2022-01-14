using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamsRSSFeed.Domain.Interfaces.Repository;
using TeamsRSSFeed.Domain.Models;
using TeamsRSSFeedApi.Models.Request;

namespace TeamsRSSFeedApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly ILogger<FeedController> _logger;
        private readonly IFeedRepository _feedRepository;
        private readonly IFeedItemRepository _feedItemRepository;

        public FeedController(
            ILogger<FeedController> logger,
            IFeedRepository feedRepository,
            IFeedItemRepository feedItemRepository
        )
        {
            _logger = logger;
            _feedRepository = feedRepository;
            _feedItemRepository = feedItemRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateFeedRequest request)
        {
            _logger.LogDebug($"Creating {nameof(Feed)}: {request.Title} - {request.Description}");

            var feed = _feedRepository.GetByTitle(request.Title);
            if (feed != null)
                return Conflict($"{nameof(Feed)}: '{request.Title}' already exists");

            feed = _feedRepository.Create(request.Title, request.Description);

            return Created("", feed);
        }

        [HttpGet]
        [Route("{title}")]
        public IActionResult Get([Required]string title)
        {
            _logger.LogDebug($"Getting {nameof(Feed)}: {title}");

            var feed = _feedRepository.GetByTitle(title);
            if (feed == null)
                return NotFound();

            // TODO: Map domain to response model

            return Ok(feed);
        }

        [HttpGet]
        [Route("{title}/Items")]
        public IActionResult GetItems([Required] string title)
        {
            _logger.LogDebug($"Getting {nameof(Feed)}: {title}");

            var feed = _feedRepository.GetByTitle(title);
            if (feed == null)
                return NotFound();

            var items = _feedItemRepository.GetByFeed(feed.Id);

            return Ok(items);
        }
    }
}
