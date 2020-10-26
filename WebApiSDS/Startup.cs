using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using SDS.Core.ApplicationService.Service;
using SDS.Core.ApplicationService;
using SDS.Core.DomainService;
using SDS.Infrastructure.Data;
using SDS.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WebApiSDS
{
    public class Startup
    {

            public Startup(IConfiguration configuration, IWebHostEnvironment env)
            {
                Configuration = configuration;
                Environment = env;
            }

            public IConfiguration Configuration { get; }
            public IWebHostEnvironment Environment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                });

                services.AddCors(options =>
                    {
                        options.AddPolicy(name: "CustomerAppAllowSpecificOrigins",
                            builder =>
                            {
                                builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .WithMethods();
                            });
                    });
                if (Environment.IsDevelopment())
                {
                    services.AddDbContext<Context>(opt => { opt.UseSqlite("Data Source=weddingApp.db"); }
                    );
                }
                else
                {
                    services.AddDbContext<Context>(opt => { }
                        //opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"))
                        );
                }
            services.AddScoped<IAvatarRepository, AvatarRepo>();
                services.AddScoped<IAvatarService, AvatarService>();
                services.AddScoped<IOwnerRepository, OwnerRepo>();
                services.AddScoped<IOwnerService, OwnerService>();
                services.AddScoped<ITypeRepository, TypeRepo>();
                services.AddScoped<ITypeService, TypeService>();
                services.AddTransient<IDBInitializer, DBInitializer>();
                services.AddControllers();
                services.AddSwaggerGen();
                services.AddMvc().AddNewtonsoftJson();
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                services.AddControllers().AddNewtonsoftJson(options =>
                {    // Use the default property (Pascal) casing
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.MaxDepth = 2;  // 100 pet limit per owner
                });
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    // Initialize the database
                    var services = scope.ServiceProvider;
                    var ctx = scope.ServiceProvider.GetService<Context>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    var dbInitializer = services.GetService<IDBInitializer>();
                    dbInitializer.InitData(ctx);
                }
            }
            else
            {
                app.UseHsts();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<Context>();
                    ctx.Database.EnsureCreated();
                }
            }

            app.UseSwaggerUI(c =>{
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                        c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors("CustomerAppAllowSpecificOrigins");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
               {
               endpoints.MapControllers();
               });
            }
           }
        }
 
