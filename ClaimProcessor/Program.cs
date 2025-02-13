
using ClaimProcessor.Mappers;
using ClaimProcessor.Models;
using ClaimProcessor.Repositories;
using ClaimProcessor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ServiceStack;

namespace ClaimProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
            builder.Services.AddScoped<IClaimService, ClaimService>();
            builder.Services.AddScoped<INdcRepository, NdcRepository>();
            builder.Services.AddScoped<IPriceService, PriceService>();
            builder.Services.AddDbContextFactory<ClaimDBContext>(
                 options =>
                  options
                      .UseInMemoryDatabase("Settlement")
                      .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
             );
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
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
