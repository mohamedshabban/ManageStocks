using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;
using EGID.Test.API.Data;
using Microsoft.EntityFrameworkCore;
using EGID.Test.API.Data.UnitOfWork;
using EGID.Test.API.Data.Services;

namespace EGID.Test.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
                options.OutputFormatters
                .Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                }));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen();

            services.AddDbContext<EGIDDbContext>(options =>
                            options.UseSqlServer(
                                Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBrokerService, BrokerService>();
            services.AddTransient<IStockService, StockService>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder
                                        .AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type=ReferenceType.SecurityScheme,
                                        Id="Bearer"
                                    }
                                },
                                new string[]{}
                            }
                        });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("_myAllowSpecificOrigins");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
