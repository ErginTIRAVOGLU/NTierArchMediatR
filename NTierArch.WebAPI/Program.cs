using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NTierArch.Business;
using NTierArch.DataAccess;
using NTierArch.Entities.Options;
using NTierArch.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

//DependencyInjections
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));

var serviceProvider = builder.Services.BuildServiceProvider();
var jwtConfiguration = serviceProvider.GetRequiredService<IOptions<Jwt>>().Value;

builder.Services.AddAuthentication().AddJwtBearer(jwtConfigure =>
{
    jwtConfigure.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = jwtConfiguration.Issuer,
        ValidAudience = jwtConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusiness();

//ExceptionMiddleware app start new ExceptionMiddleware() to application exit lifetime
builder.Services.AddTransient<ExceptionMiddleware>();
//ExceptionMiddleware app start new ExceptionMiddleware() to application exit lifetime

//DependencyInjections

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Swagger Advance Options
builder.Services.AddSwaggerGen(swaggerSetup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Sadece JWT Bearer tokeninizi aþaðýdaki metin kutusuna yerleþtirin!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    swaggerSetup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    swaggerSetup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
//Swagger Advance Options

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//ExceptionMiddleware Dependency Injection
app.UseMiddleware<ExceptionMiddleware>();
//ExceptionMiddleware Dependency Injection

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
