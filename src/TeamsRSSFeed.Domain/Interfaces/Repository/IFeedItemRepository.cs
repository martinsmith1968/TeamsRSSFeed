using System;
using System.Collections.Generic;
using TeamsRSSFeed.Domain.Models;

namespace TeamsRSSFeed.Domain.Interfaces.Repository
{
    public interface IFeedItemRepository
    {
        FeedItem Get(Guid id);

        IEnumerable<FeedItem> GetByFeed(Guid feedId);

        FeedItem Create(Guid feedId, string text);
    }
}
