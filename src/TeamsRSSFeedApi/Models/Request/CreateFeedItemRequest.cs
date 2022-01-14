using System.ComponentModel.DataAnnotations;

namespace TeamsRSSFeedApi.Models.Request
{
    public class CreateFeedItemRequest
    {
        [Required]
        public string Text { get; set; }

        public string Category { get; set; }    // TODO: Different to Feed.Title ?

        public string Importance { get; set; }  // TODO: Enum ?

        public string[] Tags { get; set; }
    }
}
