using Hobdex.Api.Data;
using Hobdex.Api.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<HobdexDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/hobbies", async (HobdexDbContext db) =>
{
    var hobbies = await db.Hobbies
        .Select(h => new HobbyDto
        {
            Id = h.Id,
            Name = h.Name,
            ImageUrl = h.ImageUrl,
            Description = h.Description,
            IconName = h.IconName,
            TotalProjects = 0,
            CompletedProjects = 0,
            InProgressProjects = 0
        })
        .ToListAsync();

    return Results.Ok(hobbies);
});

app.UseCors("AllowClient");

app.Run();
