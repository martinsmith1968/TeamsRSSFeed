using System;
using TeamsRSSFeed.Domain.Models;

namespace TeamsRSSFeed.Domain.Interfaces.Repository
{
    public interface IFeedRepository
    {
        Feed Get(Guid id);

        Feed GetByTitle(string title);

        Feed Create(string title, string description);
    }
}
