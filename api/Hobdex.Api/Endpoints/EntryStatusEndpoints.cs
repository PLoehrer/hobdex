using Hobdex.Api.Data;
using Hobdex.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Hobdex.Api.Endpoints;

public static class EntryStatusEndpoints
{
    public static void MapEntryStatusEndpoints(this WebApplication app)
    {
        app.MapGet("/entry-statuses", async (HobdexDbContext db) =>
        {
            var statuses = await db.EntryStatuses
                .Select(s => new EntryStatusDto(s.Id, s.Name))
                .ToListAsync();
            return Results.Ok(statuses);
        });
    }
}