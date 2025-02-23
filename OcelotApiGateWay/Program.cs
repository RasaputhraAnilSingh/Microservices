using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Load Ocelot configuration from Ocelot.json
builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);

// Add Ocelot services to the container
builder.Services.AddOcelot(builder.Configuration);

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],  // Issuer from appsettings.json
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],  // Audience from appsettings.json
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))  // Secret Key from appsettings.json
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Ensure that the Authentication and Authorization middlewares are used first
app.UseAuthentication();  // Enable authentication for validating JWT tokens
app.UseAuthorization();   // Enable authorization for checking permissions

// Add Ocelot middleware (API Gateway routing) - Ocelot should be placed after authentication and authorization
await app.UseOcelot(); // Use Ocelot to route requests

app.Run();
