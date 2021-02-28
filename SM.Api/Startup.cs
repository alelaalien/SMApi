using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SM.Core.Interfaces;
using SM.Core.Services;
using SM.Infraestructure.Data;
using SM.Infraestructure.Interfaces;
using SM.Infraestructure.Options;
using SM.Infraestructure.Repositories;
using SM.Infraestructure.Services;
using System;
using System.Text;

namespace SM.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers()
                .AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;})
                .ConfigureApiBehaviorOptions(options =>{ 
                 options.SuppressModelStateInvalidFilter = true;});

            services.AddDbContext<SMContext>(options=> options.UseSqlServer("Server=DESKTOP-OAU6F0C\\SQLEXPRESS; Database=SM; User Id=gttt; Password=gttt"));
            services.Configure<PasswordOptions>(Configuration.GetSection("PasswordOptions"));
            services.AddSingleton<IPasswordHasher, PasswordService>();
             services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITypeOfService, TypeOfService>();
            services.AddTransient<IDictatesService, DictatesService>(); 
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ISubjetService, SubjetService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
           
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };

            });


            services.AddMvc(//options =>{     options.Filters.Add<ValidationFilter>();}
                )
                .AddFluentValidation(options =>{
                options.RegisterValidatorsFromAssemblies (AppDomain.CurrentDomain.GetAssemblies()); });
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "SM Api", Version = "v1" });
             
            });
            }






        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SM Api");
             ///  options.RoutePrefix = string.Empty;
            });

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
