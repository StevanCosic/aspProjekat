using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PorjekatDataAccsess;
using ProjekatiApplication;
using ProjekatiApplication.commands;
using ProjekatImplementation.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.core;
using ProjekatImplementation.validation;
using ProjekatiApplication.queries;
using ProjekatImplementation.queries;
using ProjekatImplementation.logger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjekatiApplication.emailSender;
using ProjekatImplementation.Email;

namespace api
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
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddTransient<IcreateGroupeCommand, EfCreateGroupeCommand>();
            services.AddTransient<ProjekatDbContext>();
            services.AddTransient<iDeledeGroupeCommand, EFdeleteGroupCommand>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUser>();
            services.AddTransient<IAplicationActor>(x=>
            {
                var accesor = x.GetService<IHttpContextAccessor>();

                var user = accesor.HttpContext.User;

                if(user.FindFirst("ActorData") == null)
                {
                    return new NonAccountUser();
                }
                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<jwtActor>(actorString);


                return actor;
            });
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<createGroupValidator>();
            services.AddTransient<IgetGroupQuery, EFgetGroup>();
            services.AddTransient<caseLogger, DataBaseUseCaseLogger>();
            services.AddTransient<jwtManager>();
            services.AddTransient<registrationValidator>();
            services.AddTransient<IEmailSender, SMTPEmailSender>();
            services.AddTransient<ICreateNewCarMark, EFNewCarMark>();
            services.AddTransient<IAddTypeCar,EFAddCarType>();
            services.AddTransient<IAddDriver, EFAddDriver>();
            services.AddTransient<driverValidation>();
            services.AddTransient<IgetCommandsLogQuery, EfGetCommandQuery>();
            services.AddTransient<IaddMessage, EFmessage>();
            services.AddTransient<IdeleteMessage, EFdeleteMessage>();
            services.AddTransient<IshowMyMessage, EFGetMyMessage>();
            services.AddTransient<IGetAllMessages, EFgetALlmessage>();
            services.AddTransient<IAddVoznju, EFAddVoznju>();
            services.AddTransient<driveValidator>();
            services.AddTransient<IMyDrives, EFMyDrives>();
            services.AddTransient<IAllDrives, EFAllDrives>();








            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });









        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
                x.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseMiddleware<globalExHendling>();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
