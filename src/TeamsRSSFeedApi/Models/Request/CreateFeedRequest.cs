using System.ComponentModel.DataAnnotations;

namespace TeamsRSSFeedApi.Models.Request
{
    public class CreateFeedRequest
    {
        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
