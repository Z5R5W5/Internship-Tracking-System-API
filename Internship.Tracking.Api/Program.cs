
using FluentValidation;
using Internship.Application;
using Internship.Application.Behaviors;
using Internship.Infrastructure.Data;
using Internship.Tracking.Api.Extentions;
using Internship.Tracking.Api.Middlewares;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Internship.Tracking.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database Dependencies 

            builder.Services.AddDbContext<InternshipDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("InternshipDbConnection")));

            //Mediator Dependencies
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly);
            });

            // fluent validation dependencies
            builder.Services.AddValidatorsFromAssembly(typeof(AssemblyMarker).Assembly);

            // Application Services Dependencies

            builder.Services.AddApplicationServices();

            // pipeline behaviors
            builder.Services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>)
            );



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
                //app.MapOpenApi();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
