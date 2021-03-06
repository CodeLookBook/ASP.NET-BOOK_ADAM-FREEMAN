﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this.Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddMvc();

            // sets up the in-memory data store
            services.AddMemoryCache();

            // registers the services used to access session data
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            // allows the session system to automatically associate requests 
            // with sessions when they arrive from the client
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{Category}/Page{page:int}",
                    defaults: new { controller = "Product", action = "List"  });

                routes.MapRoute(
                    name: null,
                    template: "Page{Page:int}",
                    defaults: new { controller = "Product", action = "List", page = 1});

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", page = 1 });

                routes.MapRoute(
                    name: null, 
                    template: "", 
                    defaults: new { controller = "Product", action = "List", page = 1 });

                routes.MapRoute(
                    name: null, 
                    template: "{controller}/{action}/{id?}");
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
