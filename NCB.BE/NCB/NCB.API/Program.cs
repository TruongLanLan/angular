using Microsoft.EntityFrameworkCore;
using NCB.Application.Implementations;
using NCB.Application.Interfaces;
using NCB.Common;
using NCB.DataAccess.EF;
using NCB.DataAccess.EF.Implementations;
using NCB.DataAccess.EF.Interfaces;
using NCB.DataAccess.EF.UoW;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NCBDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection")));

//Repo
builder.Services.AddTransient<IUserRepository, UserRepository>();

//service
builder.Services.AddTransient<IUserService, UserService>();


//UnitOfWork
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//Mapper
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
