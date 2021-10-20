using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using petBlog.Data;
using petBlog.Services;

namespace petBlog
{
    public class Startup
    {
        
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AnimalContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            services.AddTransient<IService , Service>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, AnimalContext ctx)
        {

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Animal}/{action=Index}/{id?}");

            });
        }
    }
}
