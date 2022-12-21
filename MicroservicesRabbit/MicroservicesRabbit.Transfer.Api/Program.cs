using MediatR;
using Microsoft.OpenApi.Models;
using MicroservicesRabbit.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;
using MicroservicesRabbit.Infra.IoC;
using MicroservicesRabbit.Domain.Core.Bus;
using MicroservicesRabbit.Transfer.Domain.Events;
using MicroservicesRabbit.Transfer.Domain.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transfer Microservice", Version = "v1" });
});
builder.Services.AddDbContext<TransferDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"));
});

builder.Services.AddMediatR(typeof(Program));


RegisterServices(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
ConfigureEventBus(app);
app.Run();



static void ConfigureEventBus(WebApplication app)
{
   var eventBus = app.Services.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
}

static void RegisterServices(IServiceCollection services)
{
    TransferDependencyContainer.RegisterServices(services);
}
