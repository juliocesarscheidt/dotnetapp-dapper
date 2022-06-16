using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data;
using MySql.Data.MySqlClient; // MySqlConnection

using Api.Domain.Repository;
using Api.Application.Service;

using Api.Infra.Repository;
using Api.Infra.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

ConfigurationManager configuration = builder.Configuration;
// Read the connection string from appsettings.
string dbConnectionString = configuration.GetConnectionString("dbConnection");

// service locators - dependency injection
builder.Services.AddTransient<IDbConnection>((sp) => new MySqlConnection(dbConnectionString));
builder.Services.AddScoped<IMessageService, MessageService>();
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
