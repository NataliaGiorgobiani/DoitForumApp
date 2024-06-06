using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entities
{
    public class ForumEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }


        [Required]
        public Status Status { get; set; } = Status.Active;

        [Required]
        public State State { get; set; } = State.Pending;

        //[Required]
      //  public string ForumUserID { get; set; }
    }

    public class Comments
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ForumEntityId { get; set; }

        [Required]
        [StringLength(500)]
        public string TopicComent { get; set; }

        [Required]
        public string UserID { get; set; }


    }
}
