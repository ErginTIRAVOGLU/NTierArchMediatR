using NTierAcrh.Business;
using NTierAcrh.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//DependencyInjections
builder.Services.AddBusiness();
builder.Services.AddDataAccess(builder.Configuration);
//DependencyInjections

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();