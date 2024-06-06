
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class CommentForGettingDto
    {
        public int Id { get; set; }
        public int ForumEntityId { get; set; }
        public string TopicComent { get; set; }
        public string UserID { get; set; }
    }
}
