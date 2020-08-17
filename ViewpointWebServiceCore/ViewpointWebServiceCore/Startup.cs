using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ViewpointWebServiceCore
{
    public class Startup
    {
        readonly string AllowedOrigins = "_AllOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1 " + DateTime.Now.ToString(),
                    Title = "ViewPointWebServiceCore",
                    Description = "ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Authors: Willdan Strategic Development Team",
                        //Email = "Contacts: JWorrall@willdan.com, JAsuncion@Willdan.com, VYekklurBalaji@willdan.com",
                        Url = new Uri("https://Wiildan.com/"),
                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOrigins,
                                  builder =>
                                  {
                                      builder
                                      .AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            services.AddSwaggerGenNewtonsoftSupport();

            var issuer = "https://dev-317836.okta.com/oauth2/default";
            //var issuer = "https://dev-878852.okta.com/oauth2/default";
            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        issuer + "/.well-known/oauth-authorization-server",
                        new OpenIdConnectConfigurationRetriever(),
                        new HttpDocumentRetriever());

            var signingKeys = Task.Run(async () =>
            {
                OpenIdConnectConfiguration discoveryDocument = await configurationManager.GetConfigurationAsync(default(CancellationToken));
                return discoveryDocument.SigningKeys;
            }).GetAwaiter().GetResult();

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    RequireSignedTokens = false,
                    ValidateAudience = true,
                    ValidAudience = "api://default",
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKeys = signingKeys,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(2)
                };

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(AllowedOrigins);
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "OnlinePortalWebApiCore");
            });
        }
    }
}
