using DataAccess.Context;
using DataAccess.Services;
using InventoryApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IInventoryContext, InventoryContext>();
builder.Services.AddTransient<IInventoryService, InventoryService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.ConfigureApi();

app.Run();
