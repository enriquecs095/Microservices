using EventTickets.Contexts;
using EventTickets.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTickets
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EventCatalogDbContext>(o => o.UseSqlite("Data Source =events.db"));
            services.AddScoped<ICategoryRepository, CategoryRepository>();//para agregar las interfaces
            services.AddScoped<IEventRepository, EventRepository>();//para agregar las interfaces
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var scope = app.ApplicationServices.CreateScope();//este es mejor y nuevo
            using var context = scope.ServiceProvider.GetRequiredService<EventCatalogDbContext>();
            context.Database.EnsureCreated();
            /*
            using (var scope=app.ApplicationServices.CreateScope()) {//con esto creo la base de datos antes de todo
                using (var context = scope.ServiceProvider.GetRequiredService<EventCatalogDbContext>()) {
                    context.Database.EnsureCreated();
                }
            }*/
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
             
            });
        }
    }
}
/*   endpoints.MapGet("/", async context => imprimir mensaje de que funciona
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/ 
