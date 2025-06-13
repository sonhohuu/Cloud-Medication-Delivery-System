using Medication_Order_Service.API;
using Medication_Order_Service.Application;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Infrastructure;
using Medication_Order_Service.Infrastructure.Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSignalR();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddHttpContextAccessor();

ServiceRegister.RegisterServices(builder.Services, builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
