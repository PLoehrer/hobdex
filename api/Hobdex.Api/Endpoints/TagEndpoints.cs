using Hobdex.Api.Data;
using Hobdex.Api.DTOs;
using Hobdex.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hobdex.Api.Endpoints;

public static class TagEndpoints
{
    public static void MapTagEndpoints(this WebApplication app)
    {
        app.MapGet("/tags/{userId:int}", async (int userId, HobdexDbContext db) =>
        {
            var tags = await db.Tags
                .Where(t => t.UserId == userId)
                .Select(t => new TagDto(t.Id, t.Name, t.Color))
                .ToListAsync();
            return Results.Ok(tags);
        });

        app.MapPost("/tags", async (CreateTagDto dto, HobdexDbContext db) =>
        {
            var now = DateTime.UtcNow;
            var tag = new Tag
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Color = dto.Color,
                CreatedOn = now,
                UpdatedOn = now,
                CreatedBy = dto.UserId,
                UpdatedBy = dto.UserId
            };
            db.Tags.Add(tag);
            await db.SaveChangesAsync();
            return Results.Created($"/tags/{tag.Id}", new TagDto(tag.Id, tag.Name, tag.Color));
        });
    }
}