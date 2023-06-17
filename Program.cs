using AutoMapper;
using EpiConnectAPI.Core.MapConfiguration;
using EpiConnectAPI.Data;
using EpiConnectAPI.Data.Repository.Interfaces;
using EpiConnectAPI.Data.Repository.Implementation;
using EpiConnectAPI.Services.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EpiConnectAPI.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(opt => {
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "EPI-CONNECT_API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Name = "Authorization",

        Description = "Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

//builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("EpiConnect"));
builder.Services.AddDbContext<AppDbContext>(opt => {
    //opt.UseMySQL(builder.Configuration.GetConnectionString("EpiConnectMysql"));
    opt.UseSqlServer(builder.Configuration.GetConnectionString("EpiConnect"));
});
builder.Services.AddSignalR();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEpiRepository, EpiRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization(opt => {
    opt.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme) //todos os endpoints necessitam de um token para serem acessados
    .RequireAuthenticatedUser()
    .Build();
});
builder.Services.AddAuthentication(authOpt => {
    authOpt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOpt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwtOpt => {
        jwtOpt.TokenValidationParameters = new TokenValidationParameters() {
            ValidateActor = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtBearerTokenSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtBearerTokenSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtBearerTokenSettings:SecretKey"]))
        };
    });

IMapper mapper = MapConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAnyOrigin", builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseRouting();
#pragma warning restore ASP0014 // Suggest using top level route registrations
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapHub<WebSocketHub1>("/websocket1").AllowAnonymous();
    endpoints.MapHub<WebSocketHub2>("/websocket2").AllowAnonymous();
    endpoints.MapHub<WebSocketHub3>("/websocket9").AllowAnonymous();
});
app.MapControllers();

app.Run();
