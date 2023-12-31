﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomerAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CustomerAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerAPIContext") ?? throw new InvalidOperationException("Connection string 'CustomerAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyOrigin());

app.MapControllers();

app.Run();
