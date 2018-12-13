using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Taskier.Core.DataLayer;
using Taskier.Core.ServiceLayer;
using Taskier.Data;
using Taskier.Domain.ViewModel.Request.TaskController;
using Taskier.Services;

namespace Taskier.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        { 
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Data.Configure.MappingProfile());
                mc.AddProfile(new Services.Configuration.MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddMvc().AddFluentValidation().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<TaskierContext>((obj) =>
            {
                obj.UseSqlServer(Configuration.GetConnectionString("Default"), opt => opt.MigrationsAssembly("Taskier.Data"));
            });

            //Validators
            services.AddTransient<IValidator<CreateTaskRequest>, CreateTaskRequestValidator>();

            //Services
            services.AddScoped<IRepoFactory, RepoFactory>();
            services.AddScoped<IServiceFactory, ServiceFactory>();

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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
