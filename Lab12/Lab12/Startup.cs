using Microsoft.AspNetCore.Builder;
using Lab12.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab12.Models.Services;
using Lab12.Models.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Lab12.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Lab12
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HotelDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // ADD SWAGGER HERE
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Async Inn",
                    Version = "v1",
                });
            });

            //IDENTITY 
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<HotelDbContext>();

            //AUTHENTICATION Services
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    // Tell the authenticaion scheme "how/where" to validate the token + secret
                    options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
                });
            //AUTHORIZATION Services
            services.AddAuthorization(options =>
            {
                // Add "Name of Policy", and the Lambda returns a definition
                options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
                options.AddPolicy("read", policy => policy.RequireClaim("permissions", "read"));
                options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
                options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
            });

            //Dependency injections
            services.AddTransient<IHotel, HotelService>();
            services.AddTransient<IRoom, RoomServices>();
            services.AddTransient<IAmenities, AmenityServices>();
            services.AddTransient<IHotel_Room, Hotel_RoomServices>();

            //Add this for the login portion
            services.AddTransient<IUser, IdentityUserService>();

            //This is for the token
            services.AddScoped<JwtTokenService>();


            //this came from john on the demo code
            services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //AUTHENTICATION & AUTHORIZATION
            app.UseAuthentication();
            app.UseAuthorization();

            //SWAGGER - ROUTE
            app.UseSwagger(options =>{
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            //SWAGGER - DOCUMENTATION
            app.UseSwaggerUI(options =>{
                options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn");
                options.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints =>{
                endpoints.MapControllers();
            });
        }
    }
}
