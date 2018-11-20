using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreFramework.Infrastructure.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using NetCoreFramework.Application.Core.Students;
using NetCoreFramework.Application.Core.DTO.TestPurpose;
using NetCoreFramework.Presentation.WebAPI.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Swagger;

namespace NetCoreFramework.Presentation.WebAPI
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
            services.AddDbContext<FrameworkContext>(options =>
            options.UseSqlServer("Server=localhost;Database=NetCoreFramework;Trusted_Connection=True;MultipleActiveResultSets=true").EnableSensitiveDataLogging(true));

            services.AddScoped<IStudentService, StudentService>();

            services.AddMvc(/*options=> options.Filters.Add(typeof(ValidateModelStateAttribute))*/).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddCors();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
                ).AddJwtBearer(options =>
                {

                    options.Events = new JwtBearerEvents()
                    {
                        OnChallenge = context =>
                        {
                            // Skip the default logic.
                            context.HandleResponse();

                            var payload = new JObject
                            {
                                ["error"] = "Needed valid token to authorize!",
                                ["statusCode"] = 401
                            };
                            context.Response.StatusCode = 401;
                            return context.Response.Body.WriteAsync(Encoding.Default.GetBytes(payload.ToString())).AsTask();
                        }
                    };

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Jwt Key Jwt Key Jwt Key Jwt Key Jwt Key")),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                });


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1doc", new Info { Title = "NetCoreFramework.Presentation.WebAPI", Version = "1.0" });

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });




            ProfileRegistration.RegisterMapping();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(action => action.AllowAnyOrigin().AllowCredentials());
            app.UseMvc();
            app.UseAuthentication();

            app.UseStaticFiles();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();



            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1doc/swagger.json", ".Net Core Framework WEB API V1");
            });
        }
    }
}
