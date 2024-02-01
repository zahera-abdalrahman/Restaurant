using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resturant.Models;
using Resturant.Models.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Resturant
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddDbContext<AppDbContext>(x =>
            {


                x.UseSqlServer(Configuration.GetConnectionString("SqlCon"));


            });
            services.AddScoped<IRepository<MasterCategoryMenu>, MasterCategoryMenuRepository>();
            services.AddScoped<IRepository<MasterContactUsInformation>, MasterContactUsInformationRepository>();
            services.AddScoped<IRepository<MasterItemMenu>, MasterItemMenuRepository>();
            services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
            services.AddScoped<IRepository<MasterOffer>, MasterOfferRepository>();
            services.AddScoped<IRepository<MasterPartner>, MasterPartnerRepository>();
            services.AddScoped<IRepository<MasterService>, MasterServiceRepository>();
            services.AddScoped<IRepository<MasterSlider>, MasterSliderRepository>();
            services.AddScoped<IRepository<MasterSocialMedium>, MasterSocialMediumRepository>();
            services.AddScoped<IRepository<MasterWorkingHour>, MasterWorkingHourRepository>();
            services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
            services.AddScoped<IRepository<TransactionBookTable>, TransactionBookTableRepository>();
            services.AddScoped<IRepository<TransactionContactUs>, TransactionContactUsRepository>();
            services.AddScoped<IRepository<TransactionNewsletter>, TransactionNewsletterRepository>();
            services.AddScoped<IRepository<MasterAbout>, MasterAboutRepository>();
            services.AddScoped<IRepository<Customer>, CustomerRepository>();

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                //options here

                options.LoginPath = "/Admin/Account/Login";

                //...
            });

            services.Configure<IdentityOptions>(x =>
            {

                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 7;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;

            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();



             app.UseMvc();

            app.UseHttpsRedirection();
            app.UseCookiePolicy();

 

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=index}/{id?}"

                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}"

                    );

            });

        }
    }
}
