using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Business;
using Entities.Constants.FiConstants;
var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});

builder.Services.Configure<FiNewAccountsCodes>(builder.Configuration.GetSection(nameof(FiNewAccountsCodes)));
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});
//// Configure JWT authentication
string secretKey = Environment.GetEnvironmentVariable("SecretKey");
string ValidIssuer = Environment.GetEnvironmentVariable("ValidIssuer");
string ValidAudience = Environment.GetEnvironmentVariable("ValidAudience");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = ValidIssuer,
            ValidAudience = ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddTransient<FiNewAccountsCodes>();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
});
//    builder.Services.AddHttpMethodOverride();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
    name: "AllowOrigin",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });

});
//builder.Services.AddMvc();
//To Avoid Cycle Dependency
builder.Services.AddControllers()
    .AddNewtonsoftJson
    (c => c.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//Hussein: 2-we use sqlserver
builder.Services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer("ConnectionString"));
builder.Services.InjectEntitiesDependencies();
builder.Services.InjectRepositories();
builder.Services.InjectServices();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMS", Version = "v1" });
    //c.SwaggerDoc("Stores", new OpenApiInfo { Title = "STR", Version = "v1" });
    //c.SwaggerDoc("Finance", new OpenApiInfo { Title = "FI", Version = "v1" });
    //c.SwaggerDoc("Human Resource", new OpenApiInfo { Title = "HR", Version = "v1" });
    //c.SwaggerDoc("Privileges", new OpenApiInfo { Title = "Pr", Version = "v2" });
    //c.SwaggerDoc("PayRoll", new OpenApiInfo { Title = "PY", Version = "v1" });

    //c.TagActionsBy(api => new[] { api.GroupName });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMS v1"));

app.MapControllers();

app.Run();
