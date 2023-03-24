using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcArcheryWebshop.Models;

namespace MvcArcheryWebshop


{
    public class Startup
    {
        // ...

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IProductRepository, InMemoryProductRepository>();
        }




        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "product/{id}",
                    defaults: new { controller = "Product", action = "Index" });

                // ...
            });
        }
    }
}
