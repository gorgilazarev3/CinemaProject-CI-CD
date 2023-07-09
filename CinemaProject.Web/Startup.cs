//using CinemaProject.Web.Data;
using CinemaProject.Domain.Identity;
using CinemaProject.Repository;
using CinemaProject.Repository.Implementation;
using CinemaProject.Repository.Interface;
using CinemaProject.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<CinemaUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository.Implementation.Repository<>));
            services.AddScoped(typeof(IOrderRepository), typeof(Repository.Implementation.OrderRepository));

            services.AddTransient<IUserService, Service.Implementation.UserService>();
            services.AddTransient<IMovieService, Service.Implementation.MovieService>();
            services.AddTransient<ITicketService, Service.Implementation.TicketService>();
            services.AddTransient<IShoppingCartService, Service.Implementation.ShoppingCartService>();
            services.AddTransient<IOrderService, Service.Implementation.OrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            var scope = app.ApplicationServices.CreateScope();
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetService<UserManager<CinemaUser>>();
            SeedRoles(roleManager, userManager);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private async void SeedRoles(RoleManager<IdentityRole> roleManager, UserManager<CinemaUser> userManager)
        {
            //var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var userManager = serviceProvider.GetRequiredService<UserManager<CinemaUser>>();
            if (!await roleManager.RoleExistsAsync("STANDARD_USER"))
            {
                await roleManager.CreateAsync(new IdentityRole("STANDARD_USER"));
            }
            if (!await roleManager.RoleExistsAsync("ADMIN"))
            {
                await roleManager.CreateAsync(new IdentityRole("ADMIN"));
            }
            var adminUser = await userManager.FindByEmailAsync("admin@admin");
            if (adminUser == null)
            {
                var user = new CinemaUser { FirstName = "Admin", LastName = "Admin", Age = 21, UserName = "admin@admin", Email = "admin@admin" };
                await userManager.CreateAsync(user, "Test123!");
                await userManager.AddToRoleAsync(user, "ADMIN");
            }
            else
            {
                await userManager.AddToRoleAsync(adminUser, "ADMIN");
                await userManager.RemoveFromRoleAsync(adminUser, "STANDARD_USER");
            }
        }
    }
}
