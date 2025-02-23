using Microsoft.AspNetCore.Builder;
using RentACar.Business.Abstract;
using RentACar.Business.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework;
using RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<ICarService, CarManager>();
builder.Services.AddScoped<IColorService, ColorManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IFuelService, FuelManager>();
builder.Services.AddScoped<IInvoiceService, InvoiceManager>();
builder.Services.AddScoped<ILocationService, LocationManager>();
builder.Services.AddScoped<IRentalService, RentalManager>();
builder.Services.AddScoped<ITransmissionService, TransmissionManager>();
builder.Services.AddScoped<IVehicleService, VehicleManager>();
//builder.Services.AddScoped<IBrandDal, EfBrandDal>();
//builder.Services.AddScoped<ICarDal, EfCarDal>();
//builder.Services.AddScoped<IColorDal, EfColorDal>();
//builder.Services.AddScoped<ICreditCardDal, EfCreditCardDal>();
//builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
//builder.Services.AddScoped<IFuelDal, EfFuelDal>();
//builder.Services.AddScoped<IInvoiceDal, EfInvoiceDal>();
//builder.Services.AddScoped<ILocationDal, EfLocationDal>();
//builder.Services.AddScoped<IRentalDal, EfRentalDal>();
//builder.Services.AddScoped<ITransmissionDal, EfTransmissionDal>();
//builder.Services.AddScoped<IVehicleDal, EfVehicleDal>();


builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rent A Car API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
