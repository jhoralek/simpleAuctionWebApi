using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using SA.Application.Records;
using SA.Application.Security;
using SA.Core.Model;
using SA.Core.Security;
using SA.EntityFramework.EntityFramework;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string domain = $"https://{_configuration["Auth0:Domain"]}/";

            services.AddCors(options =>
                options.AddPolicy("SA",
                    policy => policy
                        .WithOrigins(_configuration["Cors:Url"])
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = _configuration["Auth0:Audience"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
            });

            services.AddMvc(options => options.Filters.Add(new CorsAuthorizationFilterFactory("SA")))
                .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddJsonOptions(a => a.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects);

            services.AddDbContext<SaDbContext>(options => options.UseMySQL(_configuration["ConnectionString:Sa"]), ServiceLifetime.Singleton);

            services.AddSingleton<IEntityRepository<Country>, CountriesRepository>();
            services.AddSingleton<IEntityRepository<Address>, AddressesRepository>();
            services.AddSingleton<IEntityRepository<User>, UsersRepository>();
            services.AddSingleton<IEntityRepository<Customer>, CustomersRepository>();
            services.AddSingleton<IEntityRepository<Bid>, BidsRepository>();
            services.AddSingleton<IEntityRepository<File>, FilesRepository>();
            services.AddSingleton<IEntityRepository<Record>, RecordsRepository>();

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddSingleton<IRecordService, RecordService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SaDbContext>();
                context.Database.Migrate();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Users}/{action=GetAll}/{id?}");
            });
        }
    }
}
