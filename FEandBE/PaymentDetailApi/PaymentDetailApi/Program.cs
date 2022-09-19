using Microsoft.EntityFrameworkCore;
using PaymentDetailApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PaymentDetailContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
