using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApiBoilerPlate.API.DbContexts;
using WebApiBoilerPlate.API.Helpers;
using WebApiBoilerPlate.API.Helpers.Authorization;
using WebApiBoilerPlate.API.Repositories.Interfaces;
using WebApiBoilerPlate.API.Repositories.Repositories;
using WebApiBoilerPlate.API.Services.Implementations;
using WebApiBoilerPlate.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    var env = builder.Environment;


    services.AddCors();
    services.AddControllers();

    // Database Context
    services.AddDbContext<ApplicationDbContext>();

    // configure automapper with all automapper profiles from this assembly
    IMapper mapper = AutoMapperConfig.RegisterMaps().CreateMapper();
    services.AddSingleton(mapper);
    services.AddAutoMapper(typeof(Program));


    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSecret"));

    // configure DI for application services
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserService, UserService>();
}


var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

app.Run("http://localhost:4000");
