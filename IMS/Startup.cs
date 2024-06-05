using Business;
using Business.Cc;
using Business.Fa;
using Business.FI.Account;
using Business.FI.Entry;
using Business.FI.General;
using Business.HR;
using Business.PR;
using Business.Pro;
using Business.PY;
using Business.SE;
using Business.STR.Add;
using Business.STR.Employee;
using Business.STR.General;
using Business.STR.Product;
using Business.STR.StoreOpen;
using Business.STR.WithDraw;
using Business.TR.Course;
using Business.TR.Excuted;
using Business.TR.General;
using Business.TR.Instructor;
using Business.TR.Plan;
using Business.TR.Training;
using DAL;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS
{
    public class Startup
    {
        public string ConnectionString { get; set; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Hussein: 1-Which connectionstring I will use
            //ConnectionString = configuration.GetConnectionString("IMS2024");
            ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            //// Configure JWT authentication
            string secretKey = Environment.GetEnvironmentVariable("SecretKey");
            string ValidIssuer = Environment.GetEnvironmentVariable("ValidIssuer");
            string ValidAudience = Environment.GetEnvironmentVariable("ValidAudience");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            services.AddAuthorization();
            services.AddSwaggerGen(options =>
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
            //    services.AddHttpMethodOverride();
            services.AddCors(options =>
            {
                options.AddPolicy(
                name: "AllowOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });

            });
            //services.AddMvc();
            //To Avoid Cycle Dependency
            services.AddControllers()
                .AddNewtonsoftJson
                (c => c.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Hussein: 2-we use sqlserver
            services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(ConnectionString));
            services.InjectEntitiesDependencies();
            services.InjectRepositories();
            services.InjectServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMS", Version = "v1" });
                //c.SwaggerDoc("Stores", new OpenApiInfo { Title = "STR", Version = "v1" });
                //c.SwaggerDoc("Finance", new OpenApiInfo { Title = "FI", Version = "v1" });
                //c.SwaggerDoc("Human Resource", new OpenApiInfo { Title = "HR", Version = "v1" });
                //c.SwaggerDoc("Privileges", new OpenApiInfo { Title = "Pr", Version = "v2" });
                //c.SwaggerDoc("PayRoll", new OpenApiInfo { Title = "PY", Version = "v1" });

                //c.TagActionsBy(api => new[] { api.GroupName });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var secretKey = Configuration["SecretKey"];
            //var ValidIssuer = Configuration["ValidIssuer"];
            //var ValidAudience = Configuration["ValidAudience"];

            app.UseCors("AllowOrigin");

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMS v1"));

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Hussein: to send data to table
            //AppDbInitializer.Seed(app);
        }
    }
}
