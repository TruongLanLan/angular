using eShopAPI.Common;
using eShopAPI.Data.Context;
using eShopAPI.Data.UoW;
using eShopAPI.DataAccess.Implemention;
using eShopAPI.DataAccess.Interface;
using eShopAPI.Service.Implement;
using eShopAPI.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<eShopDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection")));


//Repo
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//service

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleCodeService, SaleCodeService>();
builder.Services.AddScoped<IUserService, UserService>();

//UnitOfWork


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//mapper
builder.Services.AddAutoMapper(typeof(Mapping));



// connect angular
//builder.Services.AddCors();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});



var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseCors(options => options.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader());

app.UseCors("AllowOrigin");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
