using Forum.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //მონაცემების წამოღება dataseeder-იდან.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedForum();
            modelBuilder.SeedUsers();
            modelBuilder.SeedRoles();
            modelBuilder.SeedUserRoles();
        }

        public DbSet<ForumEntity> Forum { get; set; }

    }
}
