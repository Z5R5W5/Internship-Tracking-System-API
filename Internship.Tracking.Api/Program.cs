
using FluentValidation;
using Internship.Application;
using Internship.Application.Behaviors;
using Internship.Domain.Models.identity;
using Internship.Infrastructure.Data;
using Internship.Infrastructure.Identity;
using Internship.Tracking.Api.Extentions;
using Internship.Tracking.Api.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace Internship.Tracking.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database Dependencies 

            builder.Services.AddDbContext<InternshipDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("InternshipDbConnection")));

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("InternShipIdentityDBConnection")));

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // JWT Authentication Dependencies
            builder.Services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["JsonWebToken:issuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JsonWebToken:audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JsonWebToken:key"]))


                    };
                });

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
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Internship Tracking API",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT Token"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                        });
            //builder.Services.AddOpenApi();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    builder => builder
                        .WithOrigins("http://localhost:4200") // Default Vite port
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetPreflightMaxAge(TimeSpan.FromMinutes(10))
                        );
            });

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var roleManager =
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await IdentityDbContextSeed.SeedRolesAsync(roleManager);
                await IdentityDbContextSeed.SeedUsersAsync(
                    scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>());
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
                //app.MapOpenApi();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseCors("AllowAngularApp");

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
