
using Forum.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public static class DataSeeder
    {
        public static void SeedForum(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ForumEntity>().HasData(

            new ForumEntity()
            {
                Id = 1,
                Title = "ტესტი1",
                Description = " ტესტ საკითხი 111111111",
                CreatedDate = DateTime.Now,
                State = State.Pending,
                Status = Status.Active            
            },

             new ForumEntity()
             {
                 Id = 2,
                 Title = "ტესტი2",
                 Description = " ტესტ საკითხი 222222",
                 CreatedDate = DateTime.Now,
                 State = State.Pending,
                 Status = Status.Active
             },
             new ForumEntity()
             {
                 Id = 3,
                 Title = "ტესტი2",
                 Description = " ტესტ საკითხი 333333",
                 CreatedDate = DateTime.Now,
                 State = State.Pending,
                 Status = Status.Active
             },
             new ForumEntity()
             {
                 Id = 2,
                 Title = "ტესტი4",
                 Description = " ტესტ საკითხი 444444",
                 CreatedDate = DateTime.Now,
                 State = State.Pending,
                 Status = Status.Active
             }
             );
               
        }
    }
}
