using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxAPI.DataAccess;
using DevoxAPI.DataAccess.EntityFramework;
using DevoxAPI.Loggers;
using DevoxAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DevoxAPI
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
            //Newtonsoft is required to serialize enums to strings instead of their numeric values
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            //creating logger that will write to a file and to a console.
            var consoleLogger = new ConsoleLogger();
            var fileLogger = new FileLogger("logs.txt", Serilog.RollingInterval.Day,consoleLogger);

            //registering it with the asp built-in DI mechanism.
            services.AddSingleton<IActivityRolesDataProvider, EFActivityRolesDataProvider>().
                    AddSingleton<IActivityDataProvider, EFActivityDataProvider>().
                    AddSingleton<IProjectDataProvider, EFProjectDataProvider>().
                    AddSingleton<IActivityTypeDataProvider, EFActivityTypeDataProvider>().
                    AddSingleton<IEmployeeDataProvider, EFEmployeeDataProvider>().
                    AddSingleton<LoggerBase>(fileLogger);
            //Adding required DbContext.
            services.AddDbContext<DevoxContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevoxDB")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
