using IndividualBlog.Data;
using IndividualBlog.Services.Categories;
using IndividualBlog.Services.Comments;
using IndividualBlog.Services.Posts;
using IndividualBlog.Services.Tags;
using IndividualBlog.Services.UserService;
using IndividualBlog.Utilties.Enum;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace IndividualBlog
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

            services.AddMvc();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(15);//You can set Time
            });
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
                
            },ServiceLifetime.Transient);

            //services.AddDbContext<ApplicationDbContext>(options =>
            //                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
            //        ServiceLifetime.Transient);
                                

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
            services.AddTransient<IServiceCategory, ServiceCategory>();
            services.AddTransient<IServicePost, ServicePost>();
            services.AddTransient<IServiceTag, ServiceTag>();
            services.AddTransient<IServiceUser, ServiceUser>();
            services.AddTransient<IServiceComment, ServiceComment>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapAreaControllerRoute(
                    "Admin",
                    "Admin",
                    "Admin/{controller=Home}/{action=Index}/{id?}/{slug?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
               
            });
        }
    }
}
