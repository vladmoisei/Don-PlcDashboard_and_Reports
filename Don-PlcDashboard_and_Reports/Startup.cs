using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Don_PlcDashboard_and_Reports.Data;
using Don_PlcDashboard_and_Reports.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Don_PlcDashboard_and_Reports
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
            // @"Server=172.16.4.165\SQLEXPRESS;
            services.AddDbContext<RaportareDbContext>(options =>
            options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Don_DashboardReports;User Id=user; Password=Calarasi81; MultipleActiveResultSets=true;"));


            services.AddRazorPages(); // Added for Razor Pages
            services.AddServerSideBlazor(); // Added for Blazor
            services.AddControllersWithViews();
            services.AddScoped<HttpClient>();
            //services.AddSingleton<PlcService>(); // Dispose automatically
            //services.AddSingleton(new PlcService()); // dispose mannualy or when close app
            // Added Plc service, startd directly and dispose mannualy or when close app
            services.AddSingleton(new PlcService());
            services.AddSingleton<TimedService>(); // Background Timde service
            services.AddSingleton(new DefectService()); // Defect Service Dispose mannualy or end app
            services.AddSingleton(new ReportService()); // Report Service Dispose mannualy or end app
            services.AddSingleton<StartAutBackgroundService>(); // Dispose automatically
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapBlazorHub(); // Added for blazor
            });
        }
    }
}
