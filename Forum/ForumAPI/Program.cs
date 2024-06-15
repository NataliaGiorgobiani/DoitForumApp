
namespace ForumAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddDBContext();

            builder.AddIdentity();
            builder.ConfigurJwtOptions();
            builder.AddAuthentication();
            builder.AddAuthorziation();
            builder.AddScopedServices();
            builder.AddControllers();
            builder.AddEndpointsApiExplorer();
            builder.AddSwaggerGen();
            builder.AddCors();

            var mapper = Forum.Service.MappingInitializer.Initialize();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder.Configuration.GetValue<string>("Cors:AllowOrigin"));
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
