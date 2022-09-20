using eShopBE;
using eShopBE.Application.Implement;
using eShopBE.Application.Interface;
using eShopBE.Data.Context;
using eShopBE.Data.repository.Implementstions;
using eShopBE.Data.repository.Interfaces;
using eShopBE.Data.UoW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<eShopDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection")));


//service

builder.Services.AddTransient<ICategoryService, CategoryService>();



builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(Mapping));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
