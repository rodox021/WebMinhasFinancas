using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMinhaFinancas.Data;
using WebMinhaFinancas.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Rotativa.AspNetCore;

namespace WebMinhaFinancas
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<WebMinhaFinancasContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("WebMinhaFinancasContext"),
                    builder => builder.MigrationsAssembly("WebMinhaFinancas")));
            services.AddSession(op =>
            {
                op.IdleTimeout = TimeSpan.FromDays(1);
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(op => 
            {
                op.LoginPath = "/User/Login";
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<SeedingService>();
            services.AddScoped<TypeFixedBillsService>();
            services.AddScoped<TypePayService>();
            services.AddScoped<IconService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            RotativaConfiguration.Setup(env);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Registro}/{id?}");
            });
        }
    }
}
