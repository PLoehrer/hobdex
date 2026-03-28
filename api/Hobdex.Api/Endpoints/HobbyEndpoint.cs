using Hobdex.Api.Data;
using Hobdex.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Hobdex.Api.Endpoints;

public static class HobbyEndpoints
{
    public static void MapHobbyEndpoints(this WebApplication app)
    {
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
    }
}