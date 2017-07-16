using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AreaGeode.API.Middleware;
using Swashbuckle.AspNetCore.Swagger;

namespace AreaGeode.API
{
    public class Startup
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AreaGeode V1"));
        }
    }
}
