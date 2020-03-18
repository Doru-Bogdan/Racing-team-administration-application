using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Racing_team_management.Contexts;
using Racing_team_management.Repositories.ComponentsRepository;
using Racing_team_management.Repositories.EmployeeRepository;
using Racing_team_management.Repositories.ManufacturerRepository;
using Racing_team_management.Repositories.RaceRepository;
using Racing_team_management.Repositories.TeamComponentsRepository;
using Racing_team_management.Repositories.TeamRaceRepository;
using Racing_team_management.Repositories.TeamRepository;

namespace Racing_team_management
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IComponentRepository, ComponentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<IRaceRepository, RaceRepository>();
            services.AddTransient<ITeamComponentRepository, TeamComponentRepository>();
            services.AddTransient<ITeamRaceRepository, TeamRaceRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
        }

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
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader()
                                          .AllowCredentials());
            app.UseMvc();
        }
    }
}
