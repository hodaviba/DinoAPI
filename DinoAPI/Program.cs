using DinoAPI;
using DinoAPI.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DinoAPIContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DinoAPIContext") ?? throw new InvalidOperationException("Connection string 'DinoAPIContext' not found.")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapDinoEndpoints();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
