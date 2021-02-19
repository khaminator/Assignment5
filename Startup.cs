using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Assignment5Webpage.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment5Webpage
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddDbContext<BookDbContext>(options =>

            {
                options.UseSqlServer(Configuration.GetConnectionString("BooklistConnection")); // Pass in Sql Server Connection info

            });

            services.AddScoped<iBookRepository, EFBookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsEnvironment("Development"))
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
                //Add Error Page
            //}

            app.UseDeveloperExceptionPage(); //Get info when error with website

            app.UseNodeModules();
            //app.UseDefaultFiles(); Not using this when it's with JQuery
            app.UseStaticFiles(); //This will run the html files because they are static
            //UseStaticFiles and making a public root folder didn't work for me.

            app.UseRouting(); //Route the info a certain way

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index" });  //Route it based on endpoints, use this controller and this action
            }

            );

            SeedData.EnsurePopulated(app);

        }
    }
}
