using Microsoft.EntityFrameworkCore;
using Transport.Business.Abstract;
using Transport.Business.Concrete;
using Transport.DataAccess;
using Transport.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDriversService, DriversService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<IVehiclesService, VehiclesService>();
builder.Services.AddScoped<IStatusesService, StatusesService>();
builder.Services.AddScoped<IShipmentsService, ShipmentsService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();