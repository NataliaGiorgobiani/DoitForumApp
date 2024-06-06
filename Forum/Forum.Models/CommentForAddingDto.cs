using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class CommentForAddingDto
    {
        [Required]
        public int ForumEntityId { get; set; }

        [Required]
        [StringLength(500)]
        public string TopicComent { get; set; }

        [Required]
        public string UserID { get; set; }
    }
}
