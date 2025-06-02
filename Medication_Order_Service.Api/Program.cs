using Medication_Order_Service.Application.MedicationOrders.Commands.RegisterMedicationOrder;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Infrastructure;
using Medication_Order_Service.Infrastructure.Persistence.Profiles;
using Medication_Order_Service.Infrastructure.Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // if handlers are in the API
    cfg.RegisterServicesFromAssembly(typeof(RegisterMedicationOrderCommandHandler).Assembly); // if handlers are in a separate project
});

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MedicationOrderMappingProfile));

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
