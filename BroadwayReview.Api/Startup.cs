using BroadwayReview.Api.Extensions;
using BroadwayReview.Api.Middleware;
using BroadwayReview.Application.Emails;
using BroadwayReview.Application.Logging;
using BroadwayReview.Application.Seeders;
using BroadwayReview.DataAccess;
using BroadwayReview.Implementations.Emails;
using BroadwayReview.Implementations.Logging;
using BroadwayReview.Implementations.Seeders;
using BroadwayReview.Implementations.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BroadwayReview.Api
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
            var settings = new AppSettings();
            Configuration.Bind(settings);
            services.AddSingleton(settings);
            //var connection = Configuration.GetSection("ConString").Value;
            //var connection = settings
            //services.AddBroadwayReviewContext();
            services.AddHttpContextAccessor();
            services.AddUseCases();
            services.AddValidators();
            services.AddJwt(settings);
            services.AddUser();

            services.AddTransient<ISeedFakeData, BogusDataSeeder>();
            services.AddTransient<BroadwayReviewContext>();
            services.AddTransient<IUseCaseLogger, EFUseCaseLogger>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IEmailSender>(x => new SMTPEmailSender(settings.EmailFrom, settings.EmailPassword));
            services.AddTransient<UseCaseHandler>();





            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BroadwayReview.Api", Version = "v1" });
                //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BroadwayReview.Api v1"));
            }
            app.UseStaticFiles();
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
