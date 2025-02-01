using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using FootballTeams.BL;
using FootballTeams.BL.Interfaces;
using FootballTeams.DL;
using FootballTeams.Models.Configurations;
using FootballTeams.Validators;
using FootballTeams.Bl;
using FootballTeams.ServiceExt;
using FootballTeam.MapConfig;
using Microsoft.Extensions.Logging;

namespace FootballTeam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add configurations
            builder.Services.Configure<MongoDbConfiguration>(
                builder.Configuration
                .GetSection(nameof(MongoDbConfiguration)));

            

            //Add services to the container.
            builder.Services
                .AddConfigurations(builder.Configuration)
                .RegisterDataLayer()
                .RegisterBusinessLayer();

            MapsterConfiguration.Configure();
            builder.Services.AddMapster();


            builder.Services.AddMapster();

            builder.Services.AddControllers();

            builder.Services.AddValidatorsFromAssemblyContaining<AddTeamRequestTestValidator>();

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();

            var app = builder.Build();

            app.MapHealthChecks("/Sample");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}

