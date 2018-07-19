using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using server.Managers;
using server.Providers;
using server.Services;

namespace server
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //JWT Authentication
            services.AddAuthentication(JwtBearerDefault.AuthenticationScheme).AddJwtBearer(options=>
            {
                //token validation
                options.TokenValidationParam = new TokenValidationParam
                {
                    ValidateIssuer = true
                    , ValidateAudience = true
                    , ValidateIssuerSigningKey = true
                    , ValidIssuer = "mysite.com"
                    , IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKeyStoredInConfigFile"))
                }
            });

            //Providers
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<IFeedProvider, FeedProvider>();

            //Services
            services.AddTransient<IPasswordService, PasswordService>();
            
            //Managers
            services.AddTransient<IUserManager, UserManager>();
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
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
