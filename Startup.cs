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
            if (env.IsEnvironment("Development"))
            {
                  app.UseDeveloperExceptionPage();
            }
            else
            {
                //Add Error Page
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //app.UseDeveloperExceptionPage(); //Get info when error with website

            //app.UseNodeModules();
            //app.UseDefaultFiles(); Not using this when it's with JQuery
            //This will run the html files because they are static
            //UseStaticFiles and making a public root folder didn't work for me.

            app.UseStaticFiles();

            app.UseRouting(); //Route the info a certain way

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "Books/{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                //Change the page number URL to be /P1 /P2 /P3
                endpoints.MapControllerRoute("pagination",
                    "P{page}",
                    new { Controller = "Home", action = "Index" });

                //Default endpoint - index
                endpoints.MapDefaultControllerRoute();

            }

            );

            //This connects to the SeedData.cs page.
            //To add more to the seed data use this command in terminal:
            // dotnet ef database drop --force --context BookDbContext

            //To run a migration:
            // dotnet ef migrations add Initial

            //To delete a mirgration:
            // dotnet ef migrations remove

            SeedData.EnsurePopulated(app);

        }
    }
}
