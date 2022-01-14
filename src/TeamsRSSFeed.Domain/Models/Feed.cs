using System;
using TeamsRSSFeed.Domain.Generators;

namespace TeamsRSSFeed.Domain.Models
{
    public class Feed
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AccessToken => AccessTokenGenerator.Create(this);

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? PublishedDate { get; set; }
    }
}
