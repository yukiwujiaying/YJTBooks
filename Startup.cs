using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YJKBooks.Contexts;
using Microsoft.OpenApi.Models;
using YJKBooks.Entities;

namespace YJKBooks
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

            services.AddControllersWithViews();

            //Adding AccessRouter to configurations
           // services.AddAccessRouterCookieAuthentication().AddAccessRouterOAuth(Configuration);
          //  services.AddAuthorization(options =>
          //  {
          //      options.FallbackPolicy = options.DefaultPolicy;
           // });
            



             //Adding the Swagger UI 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });

            //Adding the ConnectionString to the DBContext
            services.AddDbContext<BookStoreContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("BookInfoDBConnectionString"));

            });
            //Adding the Identity service 
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<BookStoreContext>();
            services.AddAuthentication();
            services.AddAuthorization();

            //services.AddCors();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            //Cors needs to be located exactly after UseRouting; it allows for the connection between port3002 and 5000 
            //app.UseCors(ops =>
           // {
           //     ops.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3002");
           // });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
