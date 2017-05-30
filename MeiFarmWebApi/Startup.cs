using MeiFarmWebApi.Contexts;
using MeiFarmWebApi.Interfaces;
using MeiFarmWebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MeiFarmWebApi.Models;
using System;

namespace MeiFarmWebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string conn = "Server=ALEXPC\\SQLEXPRESS;Database=FarmDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            // added the db context for the recipeContext
            // Run dotnet ef migrations add InitialCreate to scaffold a migration and create the initial set of tables for the model.
            // Run dotnet ef database update to apply the new migration to the database. This command creates the database before applying migrations.
            // dotnet ef database update 0 to return to a clean db (instead of 0 we can put the name of the migration. 0 is a clean db)
            // dotnet ef migrations remove to remove last of the migrations
            services.AddDbContext<FarmAppContext>(options => options.UseSqlServer(conn,
                optionsBuilder => optionsBuilder.MigrationsAssembly("MeiFarmWebApi")));
            /*  services.AddDbContext<IdentityDbContext>(options => 
                    options.UseSqlServer(conn, 
                        optionsBuilder => optionsBuilder.MigrationsAssembly("MeiFarmWebApi"))); 
            */
            services.AddIdentity<UserModel, IdentityRole>(options => {
                    options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                })
                .AddEntityFrameworkStores<FarmAppContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                 // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;     

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                
                // Cookie settings
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/Logout";
                
                // User settings
                options.User.RequireUniqueEmail = true;           
            });


            services.AddTransient<IConnectionService, ConnectionService>();
            services.AddTransient<IRecipeService, RecipeService>();


            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
            }
            
            loggerFactory.AddDebug();
            app.UseIdentity();
            app.UseStaticFiles(); 
            app.UseMvc();
        }
    }
}
