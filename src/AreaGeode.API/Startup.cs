using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Logging;
using AreaGeode.API.Middleware;
using Swashbuckle.AspNetCore.Swagger;

namespace AreaGeode.API
{
    /// <summary>
    /// .NET Core Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env">hosting environment</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// access to the configuration
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Configure the services - dependency injection, MVC, Swagger
        /// </summary>
        /// <param name="services">chain of services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddMvc();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", 
                    new Info
                    {
                        Title = "AreaGeode",
                        Version = "v1",
                        Description = "Geolocation information for US and Canadian Area Codes",
                        Contact = new Contact
                        {
                            Name = "Sanctuary Software Studio, Inc.",
                            Email = "support@sancsoft.com"
                        }
                    });
                    
                });
            services.ConfigureSwaggerGen(options => options.IncludeXmlComments(GetXmlCommentsPath()));
        }

        /// <summary>
        /// One time confirugration
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AreaGeode V1"));
        }

        /// <summary>
        /// Get the path the XML Comments file generated for use by Swagger
        /// </summary>
        /// <returns>path to the xml documentation</returns>
        private string GetXmlCommentsPath()
        {
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, "AreaGeode.xml");
        }
    }
}
