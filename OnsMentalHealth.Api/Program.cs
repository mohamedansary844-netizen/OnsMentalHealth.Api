using Microsoft.EntityFrameworkCore;
using OnsMentalHealth.BLL.Manager;
using OnsMentalHealth.BLL.Manager.PostManager;
using OnsMentalHealth.DAl.Repository.PostRepo;
using OnsMentalHealth.DAL.Repository;
using OnsMentalHealthSolution.DAL.Context;

namespace OnsMentalHealth.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add connection string 
            builder.Services.AddDbContext<OnsDbContext>(option => {
                option.UseSqlServer(builder.Configuration.GetConnectionString("OnsDatabase"));
            });

            builder.Services.AddMemoryCache();
            // Repositories (DAL)
            builder.Services.AddScoped<ITherapistRepo, TherapistRepo>();
            builder.Services.AddScoped<IPostRepo, PostRepo>();


            // Managers (BLL) 
            builder.Services.AddScoped<ITherapistManager, TherapistManager>();
            builder.Services.AddScoped<IPostManager, PostManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}