using Forum.Data;
using Microsoft.EntityFrameworkCore;

namespace ForumAPI
{
    public static class MiddlwareExtensions
    {
        public static void AddDBContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection")));
        }
        public static void AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }

        public static void AddEndpointsApiExplorer(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
        }

        public static void AddSwaggerGen(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
        }
    }
}
