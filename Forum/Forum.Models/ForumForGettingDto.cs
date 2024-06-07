using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Forum.Entities;

namespace Forum.Models
{
    // readonly კლასია და ვალიდაციები აქ არ გვჭირდება. უკავშირდება სერვისს.
    public class ForumForGettingDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public Status Status { get; set; }

        public State State { get; set; }

        public List<CommentForGettingDto> Comments { get; set; }
        public int TotalComments { get; set; }

    }
}
