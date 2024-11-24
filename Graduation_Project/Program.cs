
using Asp.Versioning;
using Graduation_Project.Application;
using Graduation_Project.Application.Services;
using Graduation_Project.Infrastructure;
using Graduation_Project.Infrastructure.Data;
using Graduation_Project.Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
            // Add services to the container.
            builder.Services.AddSignalR();
            builder.Services.AddControllers();

            builder.Services.AddInfrastructure(configuration).AddApplication();

            builder.Services.AddApiVersioning(opt => { 
                opt.AssumeDefaultVersionWhenUnspecified= true;
                opt.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
                opt.ReportApiVersions = true;
                // ------------ //
                opt.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));

            }).AddApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });



            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                    builder
                        .WithOrigins("http://localhost:4200")  // Your Angular app URL
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseWebSockets();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();

                context.Database.Migrate();

                var userMgr = services.GetRequiredService<UserManager<IdentityUser<Guid>>>();
                var roleMgr = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                SeedData.Initialize(context, userMgr, roleMgr).Wait();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.MapControllers();



            app.UseCors("AllowOrigin");

            app.MapHub<ChatHub>("/chatHub");
    
           


            app.Run();
        }
    }
}
