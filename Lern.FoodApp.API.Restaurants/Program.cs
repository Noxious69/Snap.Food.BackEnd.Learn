using Learn.FoodApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Novin.FoodApp.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();

SecurityServices.UseServices(app);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.MapPost("/requestlist", async (LearnFoodAppDB db) =>
{
    return Results.Ok(db.restaurants
        .Where(r => r.IsApproved == false)
        .ToList());


});

app.MapGet("/requestcount", async (LearnFoodAppDB db) =>
{
    return Results.Ok(new
    {
        Count = await db.restaurants.CountAsync(r => r.IsApproved == false)
    });
});

app.Run();
