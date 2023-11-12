using Learn.FoodApp.Infrastructure.Data;
using Learn.FoodApp.Infrastructure.UI;
using Novin.FoodApp.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);
var app = builder.Build();
SecurityServices.UseServices(app);

app.MapPost("/list", async (LearnFoodAppDB db) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());


});app.MapPost("/alist", async (LearnFoodAppDB db , ListRequestDto lr) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());


});

app.Run();
