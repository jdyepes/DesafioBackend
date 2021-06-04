using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApplicationBackend.Data.DAO;

namespace WebApplicationBackend
{
    public class Startup
    {      

        public IConfiguration Configuration { get; }

        #region parametros de conexion de la base de datos

        public static int Puerto { get; set; }
        public static string Servidor { get; set; }
        public static string NombreBD { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Password { get; set; }

        #endregion

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region parametros de conexion de la base de datos

            Servidor = Configuration["BD:servidor"];
            NombreBD = Configuration["BD:nombreBD"];
            NombreUsuario = Configuration["BD:usuario"];
            Password = Configuration["BD:password"];
            Puerto = Int32.Parse(Configuration["BD:puerto"]);

            #endregion

            services.AddControllers();

            //Serializacion para las peticiones
            services.AddControllers().AddNewtonsoftJson();

            //Acceso a las hojas de recursos
            services.AddLocalization(o => o.ResourcesPath = "Resources");    

            /// configuracion del swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0.0", new OpenApiInfo
                {
                    Version = "v1.0.0",
                    Title = "CRUD API",
                    Description = "REST API NET CORE",
                    Contact = new OpenApiContact
                    {
                        Name = "Jesus Yepes",
                        Url = new Uri("https://github.com/jdyepes"),
                        Email = "jesusyepes.1205@gmail.com"
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Inserte JWT en este campo",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // enable the annotations on Controller classes [SwaggerTag], if no class comments present
                c.EnableAnnotations();
               
            });

           // services.AddScoped<DAO>(); //se utiliza ppara que reconozca como indepencia

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "API Prueba");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
