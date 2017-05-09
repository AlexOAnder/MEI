using MeiFarmWebApi.Contexts;
using MeiFarmWebApi.Interfaces;
using MeiFarmWebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
            services.AddDbContext<FarmAppContext>(options => options.UseSqlServer(conn));
          /*  services.AddDbContext<IdentityDbContext>(options => 
                    options.UseSqlServer(conn, 
                        optionsBuilder => optionsBuilder.MigrationsAssembly("MeiFarmWebApi"))); 

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();*/

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
           /* app.UseIdentity();
            app.UseStaticFiles();  */
            app.UseMvc();
        }
    }
}
