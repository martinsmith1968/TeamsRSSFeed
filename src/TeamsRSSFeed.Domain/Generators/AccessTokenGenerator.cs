using System;
using System.Text;
using TeamsRSSFeed.Domain.Models;

namespace TeamsRSSFeed.Domain.Generators
{
    public class AccessTokenGenerator
    {
        public static string Create(Feed feed)
        {
            return Create(
                feed.Id.ToString(),
                feed.Title,
                feed.CreatedDate.ToString("s")
                );
        }

        public static string Create(params string[] parts)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join("+", parts)));
        }

        public static string[] Parse(string token)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(token))
                .Split('+');
        }
    }
}
