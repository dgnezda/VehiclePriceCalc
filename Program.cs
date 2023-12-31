using Microsoft.EntityFrameworkCore;
using VehiclePriceCalc.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<VehicleContext>(opt =>
    opt.UseInMemoryDatabase("VehicleList"));
builder.Services.AddDbContext<CalculationContext>(opt =>
    opt.UseInMemoryDatabase("CalculationList"));
builder.Services.AddDbContext<AddonContext>(opt =>
    opt.UseInMemoryDatabase("AddonList"));
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
app.MapControllers();
app.Run();
