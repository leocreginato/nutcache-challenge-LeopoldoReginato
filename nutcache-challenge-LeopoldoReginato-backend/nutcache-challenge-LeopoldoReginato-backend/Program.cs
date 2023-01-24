using Microsoft.EntityFrameworkCore;
using nutcache_challenge_LeopoldoReginato_backend.Models;
using nutcache_challenge_LeopoldoReginato_backend.Services.Contract;
using nutcache_challenge_LeopoldoReginato_backend.Services.Implementation;
using nutcache_challenge_LeopoldoReginato_backend.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBNutcacheContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
});

builder.Services.AddScoped<IGenderService,GenderService>();
builder.Services.AddScoped<ITeamService,TeamService>();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyToApp", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PolicyToApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
