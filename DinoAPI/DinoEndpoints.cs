using DinoAPI.Data;
using DinoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace DinoAPI;

public static class DinoEndpoints
{
    public static void MapDinoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Dino").WithTags(nameof(Dino));

        group.MapGet("/", async (DinoAPIContext db) =>
        {
            return await db.Dino.ToListAsync();
        })
        .WithName("GetAllDinos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Dino>, NotFound>> (int id, DinoAPIContext db) =>
        {
            return await db.Dino.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Dino model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDinoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Dino dino, DinoAPIContext db) =>
        {
            var affected = await db.Dino
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, dino.Id)
                    .SetProperty(m => m.Name, dino.Name)
                    .SetProperty(m => m.Era, dino.Era)
                    .SetProperty(m => m.Height, dino.Height)
                    .SetProperty(m => m.Weight, dino.Weight)
                    .SetProperty(m => m.Diet, dino.Diet)
                    .SetProperty(m => m.Fact, dino.Fact)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDino")
        .WithOpenApi();

        group.MapPost("/", async (Dino dino, DinoAPIContext db) =>
        {
            db.Dino.Add(dino);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Dino/{dino.Id}", dino);
        })
        .WithName("CreateDino")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, DinoAPIContext db) =>
        {
            var affected = await db.Dino
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDino")
        .WithOpenApi();
    }
}
