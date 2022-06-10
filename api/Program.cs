using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data;
using Api.Repository;
using Api.Infra.Repository;
using MySql.Data.MySqlClient; // MySqlConnection

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

ConfigurationManager configuration = builder.Configuration;
// Read the connection string from appsettings.
string dbConnectionString = configuration.GetConnectionString("dbConnection");

builder.Services.AddTransient<IDbConnection>((sp) => new MySqlConnection(dbConnectionString));
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
