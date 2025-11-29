using Microsoft.EntityFrameworkCore;
using OnsMentalHealthSolution.DAL.Context;

namespace OnsMentalHealth.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<OnsDbContext>();


            builder.Services.AddScoped<OnsMentalHealth.DAL.Repository.ITherapistRepo, OnsMentalHealth.DAL.Repository.TherapistRepo>();
            builder.Services.AddScoped<OnsMentalHealth.BLL.Manager.ITherapistManager, OnsMentalHealth.BLL.Manager.TherapistManager>();

            builder.Services.AddMemoryCache();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            var app = builder.Build();

            
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