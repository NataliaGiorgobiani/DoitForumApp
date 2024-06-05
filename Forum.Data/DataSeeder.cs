
using Forum.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
                 Id = 4,
                 Title = "ტესტი4",
                 Description = " ტესტ საკითხი 444444",
                 CreatedDate = DateTime.Now,
                 State = State.Pending,
                 Status = Status.Active
             }
             );
               
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            PasswordHasher<IdentityUser> hasher = new();

             modelBuilder.Entity<IdentityUser>().HasData(

                new IdentityUser()
                {
                    Id = "b6171e21-d7a2-48a0-9eab-cd132abb905d",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(new IdentityUser(), "Admin123"),
                    PhoneNumber = "551111111",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                   new IdentityUser()
                   {
                       Id = "20f61fa1-996f-48f8-857b-74d30f54bd57",
                       UserName = "natalia.giorgobiani1@gmail.com",
                       NormalizedUserName = "NATALIA>GIORGOBIANI1@GMAIL.COM",
                       Email = "natalia.giorgobiani1@gmail.com",
                       NormalizedEmail = "NATALIA>GIORGOBIANI1@GMAIL.COM",
                       EmailConfirmed = false,
                       PasswordHash = hasher.HashPassword(new IdentityUser(), "Natalia1"),
                       PhoneNumber = "551222222",
                       PhoneNumberConfirmed = false,
                       TwoFactorEnabled = false,
                       LockoutEnd = null,
                       LockoutEnabled = true,
                       AccessFailedCount = 0
                   },
                    new IdentityUser()
                    {
                        Id = "313ce806-e990-429e-be31-da62ef5f668d",
                        UserName = "Jonsnow@gmail.com",
                        NormalizedUserName = "JONSNOW@GMAIL.COM",
                        Email = "Jonsnow@gmail.com",
                        NormalizedEmail = "JONSNOW@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(new IdentityUser(), "Jonsnow1"),
                        PhoneNumber = "551333333",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    }
                );

        }

        public static void SeedRoles(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<IdentityRole>().HasData(
              new IdentityRole { Id = "e8609d41-3b8e-4b94-9140-f70eba53843f", Name = "Admin",NormalizedName = "ADMIN" },
              new IdentityRole { Id = "16deb40a-e05f-404e-b459-75512cebccc1", Name = "User", NormalizedName = "USER" }

              );

        }

        public static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string> { RoleId = "e8609d41-3b8e-4b94-9140-f70eba53843f", UserId = "b6171e21-d7a2-48a0-9eab-cd132abb905d" },
                new IdentityUserRole<string> { RoleId = "16deb40a-e05f-404e-b459-75512cebccc1", UserId = "20f61fa1-996f-48f8-857b-74d30f54bd57" },
                new IdentityUserRole<string> { RoleId = "16deb40a-e05f-404e-b459-75512cebccc1", UserId = "313ce806-e990-429e-be31-da62ef5f668d" }

                );
        }
    }
}
