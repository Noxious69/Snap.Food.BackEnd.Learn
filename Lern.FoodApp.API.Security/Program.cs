using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Novin.FoodApp.Infrastructure.Security;
using Training.FoodApp.API.Security.DTOs;
using Learn.FoodApp.Core.Entities;
using Learn.FoodApp.Core.Enums;
using Learn.FoodApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();

SecurityServices.UseServices(app);

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapPost("/signup", (LearnFoodAppDB db, ApplicationUsers user) =>
{
    db.ApplicationUsers.Add(user);
    db.SaveChanges();
    return Results.Ok();
});

app.MapPost("/signin", async (LearnFoodAppDB db, LoginDto login) =>
{
    if (!db.ApplicationUsers.Any())
    {
        await db.ApplicationUsers.AddAsync(new ApplicationUsers
        {
            Fullname = "modiriat",
            Password = "admin1234",
            Username = "startadmin",
            Email = "modiriat@example.com",
            Type = ApplicationUserType.SystemAdmin,

        });
        await db.SaveChangesAsync();
    }

    var result = await db.ApplicationUsers.FirstOrDefaultAsync(a => a.Username == login.Username && a.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultDto
        {
            Message = "user name ghalat",
            IsOk = false
        });
    }
    var claims = new[]
        {
            new Claim("Type" , result.Type.ToString()),
            new Claim("Username" , result.Username.ToString()),
        };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""));
    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        builder.Configuration["Jwt:Issuer"],
        builder.Configuration["Jwt:Audience"],
        claims,
        expires: DateTime.UtcNow.AddDays(3),
        signingCredentials: signIn);

    return Results.Ok(new LoginResultDto
    {
        Type = result.Type.ToString(),
        IsOk = true,
        Token = new JwtSecurityTokenHandler().WriteToken(token),
    }); ;
});
app.Run();

