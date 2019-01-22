using GolovinskyAPI.Controllers;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Infrastructure.Administration;
using GolovinskyAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Linq;
using System.Text;

namespace GolovinskyAPI
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IRepository, Repository>(provider => new Repository(connection));
            services.AddTransient<IProductRepository, ProductRepository>(provider => new ProductRepository(connection));
            services.AddTransient<ITemplateRepository, TemplateRepository>(provider => new TemplateRepository(connection));
            services.AddOptions();
            services.AddMvc();
            
            

            services.Configure<AuthServiceModel>(Configuration.GetSection("AuthService"));
            var result = Configuration.GetSection("AuthService").GetChildren();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new Info { Title = "Test Api", Description = "Swagger Test Api" });
                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"GolovinskyAPI.xml";
                c.IncludeXmlComments(xmlPath);
            }
            );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata=false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = result.Where(x => x.Key == "Issuer").FirstOrDefault().Value,
                        ValidateAudience = false,
                        ValidAudience = result.Where(x => x.Key == "Audience").FirstOrDefault().Value,
                        ValidateLifetime = true,
                        IssuerSigningKey = GetSymmetricSecurityKey(result.Where(x => x.Key == "Key").FirstOrDefault().Value),
                        ValidateIssuerSigningKey = true 
                    }; 
                });
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Test Api");
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
                    
                //RequestPath = "/mainimages"
            });
        }
    }
}
