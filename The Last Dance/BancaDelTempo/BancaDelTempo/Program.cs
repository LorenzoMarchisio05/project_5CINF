using BancaDelTempo.Controller;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SocioController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Soci Endpoint

app.MapGet("api/soci/", (SocioController controller) => controller.GetSoci());

app.MapPost("api/login/", ([FromForm] string hash) =>
{
    Console.WriteLine(hash);
});

#endregion

#region TipiSoci Endpoint

#endregion

app.Run();