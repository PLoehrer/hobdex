using Hobdex.Api.Data;
using Hobdex.Api.DTOs;
using Hobdex.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hobdex.Api.Endpoints;

public static class EntryTypeEndpoints
{
    public static void MapEntryTypeEndpoints(this WebApplication app)
    {
        app.MapGet("/entry-types/{userId:int}", async (int userId, HobdexDbContext db) =>
        {
            var types = await db.EntryTypes
                .Where(t => t.UserId == userId)
                .Select(t => new EntryTypeDto(t.Id, t.Name, t.Color, t.IsGlobal))
                .ToListAsync();
            return Results.Ok(types);
        });

        app.MapPost("/entry-types", async (CreateEntryTypeDto dto, HobdexDbContext db) =>
        {
            var now = DateTime.UtcNow;
            var entryType = new EntryType
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Color = dto.Color,
                IsGlobal = dto.IsGlobal,
                CreatedOn = now,
                UpdatedOn = now,
                CreatedBy = dto.UserId,
                UpdatedBy = dto.UserId
            };
            db.EntryTypes.Add(entryType);
            await db.SaveChangesAsync();
            return Results.Created($"/entry-types/{entryType.Id}",
                new EntryTypeDto(entryType.Id, entryType.Name, entryType.Color, entryType.IsGlobal));
        });
    }
}