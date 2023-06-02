using AutoMapper;
using EpiConnectAPI.Core.MapConfiguration;
using EpiConnectAPI.Data;
using EpiConnectAPI.Data.Repository.Interfaces;
using EpiConnectAPI.Data.Repository.Implementation;
using Microsoft.Identity.Client;
using EpiConnectAPI.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("EpiConnect"));

builder.Services.AddSignalR();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEpiRepository, EpiRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();

IMapper mapper = MapConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseRouting();
#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints => {
    endpoints.MapHub<WebSocketHub1>("/websocket1");
    endpoints.MapHub<WebSocketHub2>("/websocket2");
    endpoints.MapHub<WebSocketHub3>("/websocket9");
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.UseAuthorization();

app.MapControllers();

app.Run();
