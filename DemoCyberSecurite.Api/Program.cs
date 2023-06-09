using DemoCyberSecurite.Api.Properties;
using DemoCyberSecurite.Api.Domain.Repositories; 
using DemoCyberSecurite.Api.Domain.Services;
using System.Data;
using System.Data.SqlClient;
using Tools.Encryption;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("default")));
builder.Services.AddScoped<IAuthRepository, AuthService>();
builder.Services.AddSingleton(new RSAEncryptorTool(Resources.Keys));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
