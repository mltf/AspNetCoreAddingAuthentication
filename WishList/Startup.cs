using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WishList.Data;
using WishList.Models;

namespace WishList
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Wishlist"));
            // AddIdentity: Adds the default identity system configuration for the specified User and Role types.
            // AddEntityFrameworkStores: Adds an Entity Framework implementation of identity information stores.
            // AddDefaultTokenProviders: Adds the default token providers used to generate tokens for reset passwords, change email and change telephone number operations, and for two factor authentication token generation.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // UseAuthentication: Adds the <see cref="T:Microsoft.AspNetCore.Authentication.AuthenticationMiddleware" /> to the specified <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" />, which enables authentication capabilities.
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
