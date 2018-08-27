using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using SA.Application.Account;
using SA.Application.Country;
using SA.Application.Customer;
using SA.Application.Email;
using SA.Application.Records;
using SA.Application.Security;
using SA.Core.Model;
using SA.Core.Security;
using SA.EntityFramework.EntityFramework;
using SA.EntityFramework.EntityFramework.Repository;
using System.Linq;
using System.Reflection;

namespace SA.Web
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
            services.AddMvc();

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
                options.AddPolicy("admin", policy => policy.Requirements.Add(new HasScopeRequirement("admin", domain)));
            });

            var connectionString = _configuration["ConnectionString:CS"];
            services.AddDbContext<SaDbContext>(options => options.UseMySQL(connectionString), ServiceLifetime.Singleton);

            var controllerAssembly = Assembly.Load(new AssemblyName("SA.WebApi"));
            services.AddMvc()
                .AddApplicationPart(controllerAssembly).AddControllersAsServices()
                .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddJsonOptions(a => a.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects)
                .AddJsonOptions(a => a.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSingleton<IEntityRepository<Country>, CountriesRepository>();
            services.AddSingleton<IEntityRepository<Address>, AddressesRepository>();
            services.AddSingleton<IEntityRepository<User>, UsersRepository>();
            services.AddSingleton<IEntityRepository<Customer>, CustomersRepository>();
            services.AddSingleton<IEntityRepository<Bid>, BidsRepository>();
            services.AddSingleton<IEntityRepository<File>, FilesRepository>();
            services.AddSingleton<IEntityRepository<Record>, RecordsRepository>();
            services.AddSingleton<IEntityRepository<GdprRecord>, GdprRecordsRepository>();
            services.AddSingleton<IEntityRepository<UserActivation>, UserActivationsRepository>();

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddSingleton<IEmailConfiguration>(_configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<IUserEmailFactory, UserEmailFactory>();

            services.AddSingleton<ISecurityService, SecurityService>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Record, RecordTableDto>()
                    .ForMember(dto => dto.CurrentPrice, dto => dto.MapFrom(x => x.Bids.Any()
                        ? x.Bids.OrderByDescending(y => y.Price).FirstOrDefault().Price
                        : x.StartingPrice))
                    .ForMember(dto => dto.NumberOfBids, dto => dto.MapFrom(x => x.Bids.Count()))
                    .ForMember(dto => dto.RegistrationYear, dto => dto.MapFrom(x => x.DateOfFirstRegistration.HasValue ? x.DateOfFirstRegistration.Value.Year as int? : null));
                cfg.CreateMap<Record, RecordDetailDto>()
                    .ForMember(dto => dto.CurrentPrice, dto => dto.MapFrom(x => x.Bids.Any()
                        ? x.Bids.OrderByDescending(y => y.Price).FirstOrDefault().Price
                        : x.StartingPrice))
                    .ForMember(dto => dto.NumberOfBids, dto => dto.MapFrom(x => x.Bids.Count()));
                cfg.CreateMap<Record, RecordMinimumDto>()
                    .ForMember(dto => dto.CurrentPrice, dto => dto.MapFrom(x => x.Bids.Any()
                        ? x.Bids.OrderByDescending(y => y.Price).FirstOrDefault().Price
                        : x.StartingPrice));

                cfg.CreateMap<File, FileSimpleDto>();

                cfg.CreateMap<Bid, BidSimpleDto>()
                    .ForMember(dto => dto.UserName, dto => dto.MapFrom(x => x.User.UserName));

                cfg.CreateMap<Customer, CustomerSimpleDto>();

                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<User, UserSimpleDto>()
                    .ForMember(dto => dto.IsFeePayed, dto => dto.MapFrom(x => x.Customer.IsFeePayed))
                    .ForMember(dto => dto.PhoneNumber, dto => dto.MapFrom(x => x.Customer.PhoneNumber))
                    .ForMember(dto => dto.Email, dto => dto.MapFrom(x => x.Customer.Email));

                cfg.CreateMap<Country, CountryLookupDto>();
                cfg.CreateMap<Country, CountryDto>();
                cfg.CreateMap<Country, Country>();

                cfg.CreateMap<GdprRecord, GdprRecordTableDto>()
                    .ForMember(dto => dto.FullName, dto => dto.MapFrom(x => $"{x.FirstName} {x.LastName}"));
                cfg.CreateMap<GdprRecord, GdprRecordDto>();

                // reverse mapping
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserSimpleDto, User>();
                cfg.CreateMap<RecordDetailDto, Record>()
                    .ForMember(x => x.User, x => x.Ignore());
                cfg.CreateMap<RecordTableDto, Record>()
                    .ForMember(x => x.Files, x => x.Ignore());

                // update mapping
                cfg.CreateMap<User, User>();
                cfg.CreateMap<Record, Record>()
                    .ForMember(x => x.User, x => x.Ignore())
                    .ForMember(x => x.Files, x => x.Ignore())
                    .ForMember(x => x.Bids, x => x.Ignore());
                cfg.CreateMap<Customer, Customer>();
                cfg.CreateMap<Address, Address>();
                cfg.CreateMap<UserActivation, UserActivation>();
            });
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();

            //using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    try
            //    {
            //        var context = scope.ServiceProvider.GetRequiredService<SaDbContext>();
            //        context.Database.Migrate();
            //    }
            //    catch (Exception e)
            //    {
            //        throw e;
            //    }
            //}

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
