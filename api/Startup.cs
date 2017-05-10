using api.Authorization;
using api.Context;
using api.Context.Repository;
using api.Context.Transaction;
using api.Services;
using domain.Repositories;
using domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.Entity.Extensions;
using domain.Entities;

namespace api
{
    public partial class Startup
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
            services.AddDbContext<CdpContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationHandler, NeedsPeladaAccess>();

            services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArenaRepository, ArenaRepository>();
            services.AddScoped<IPeladaRepository, PeladaRepository>();
            services.AddScoped<IPeladaUserRepository, PeladaUserRepository>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArenaService, ArenaService>();
            services.AddScoped<IPeladaService, PeladaService>();
            services.AddScoped<IPeladaUserService, PeladaUserService>();

            // Add framework services.
            var mvc = services.AddMvc();
            mvc.AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("NeedsPeladaAccess", policy => policy.Requirements.Add(new NeedsPeladaAccessRequirement()));
            });

            services.AddSingleton(Configuration);
            services.Configure<MvcOptions>(options => options.Filters.Add(new ProducesAttribute("application/json")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CdpContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            ConfigureAuth(app);

            app.UseMvc();

            DbInitializer.Initialize(context);
        }
    }
}