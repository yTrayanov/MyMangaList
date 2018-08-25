using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMangaList.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMangaList.Models;
using MyMangaList.Common;
using AutoMapper;
using MyMangaList.Services.Users;

namespace MyMangaList.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MyMangaListContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyMangaList")));

            services.AddIdentity<User , IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<MyMangaListContext>();

            services
                .AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = this.Configuration.GetSection("Facebook:AppId").Value;
                    options.AppSecret = this.Configuration.GetSection("Facebook:AppSecret").Value;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = this.Configuration.GetSection("Google:ClientId").Value;
                    options.ClientSecret = this.Configuration.GetSection("Google:ClientSecret").Value;
                });


        services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireLowercase = true,
                    RequireDigit = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };

                //options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddAutoMapper();

            services.AddTransient(typeof(HomeService));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.SeedDatabase();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name:"default",
                    template:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
