using Amazon.S3;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Soulsplit.Api.ResolucionDependencia;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;
using Soulsplit.Api.ServiciosDistribuidos.Models;
using System.Globalization;
using System.Text;

namespace Soulsplit.Api.ServiciosDistribuidos
{
    public class Startup
    {
        readonly string SlpCors = "SlpCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddScoped<LoggerHelper>();
            services.AddResponseCaching();
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: SlpCors,
                    builder =>
                    {
                        builder.WithOrigins("*");
                        builder.WithHeaders("*");
                        builder.WithMethods("*");
                    });
            });
            services.AddRazorPages();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //jwt
            var appSettings = appSettingsSection.Get<AppSettings>();
            var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);
            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(d =>
            {
                d.RequireHttpsMetadata = false;
                d.SaveToken = true;
                d.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(llave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAWSService<IAmazonS3>();
            services.AddReCaptcha(Configuration.GetSection("ReCaptcha"));
            //SwaggerConfig.AddRegister(services);
            IoCRegisterDataContext.AddRegisterContext(services, Configuration.GetConnectionString("SoulsplitConnection"));
            IoCRegister.AddRegistration(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var cultures = new[] {
            new CultureInfo("es-ES"),
            new CultureInfo("en-US"),
        };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("es-ES"),
                SupportedCultures = cultures,
                SupportedUICultures = cultures,
            });
            app.UseForwardedHeaders();

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandlingPath = "/Error"
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(SlpCors);
            app.UseAuthentication();

            app.UseAuthorization();
            //SwaggerConfig.AddRegister(app);
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/api", async context =>
                //{

                //    context.Response.ContentType = "text/plain";

                //    // Host info
                //    var name = Dns.GetHostName(); // get container id
                //    var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
                //    Console.WriteLine($"Host Name: { Environment.MachineName} \t {name}\t {ip}");
                //    await context.Response.WriteAsync($"Host Name: {Environment.MachineName}{Environment.NewLine}");
                //    await context.Response.WriteAsync(Environment.NewLine);

                //    // Request method, scheme, and path
                //    await context.Response.WriteAsync($"Request Method: {context.Request.Method}{Environment.NewLine}");
                //    await context.Response.WriteAsync($"Request Scheme: {context.Request.Scheme}{Environment.NewLine}");
                //    await context.Response.WriteAsync($"Request URL: {context.Request.GetDisplayUrl()}{Environment.NewLine}");
                //    await context.Response.WriteAsync($"Request Path: {context.Request.Path}{Environment.NewLine}");

                //    // Headers
                //    await context.Response.WriteAsync($"Request Headers:{Environment.NewLine}");
                //    foreach (var (key, value) in context.Request.Headers)
                //    {
                //        await context.Response.WriteAsync($"\t {key}: {value}{Environment.NewLine}");
                //    }
                //    await context.Response.WriteAsync(Environment.NewLine);

                //    // Connection: RemoteIp
                //    await context.Response.WriteAsync($"Request Remote IP: {context.Connection.RemoteIpAddress}");
                //});

                endpoints.MapControllerRoute(name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
