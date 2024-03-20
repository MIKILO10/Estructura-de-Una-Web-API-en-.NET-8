using Estructura.Software.Web.API.Application.Services.Users;
using Estructura.Software.Web.API.Domain.Interfaces.Repositories;
using Estructura.Software.Web.API.Domain.Interfaces.Services.Users;
using Estructura.Software.Web.API.Infrastructure.Repositories;
using Estructura.Software.Web.API.Instances;
using Estructura.Software.Web.API.Interfaces;
using Estructura.Software.Web.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Estructura.Software.Web.API
{
    public class Startup
    {
        // Define una propiedad pública llamada Configuration de tipo IConfiguration para almacenar la configuración de la aplicación.
        public IConfiguration Configuration { get; }

        // Constructor de la clase Startup que recibe una IConfiguration como parámetro e inicializa la propiedad Configuration.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Obtiene el nombre del entorno del sistema operativo y lo asigna a la variable environmentName.
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Crea un ConfigurationBuilder y configura la ruta base para los archivos de configuración en el directorio actual.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                // Agrega un archivo de configuración JSON con el nombre específico para el entorno actual.
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

            // Construye la configuración a partir del ConfigurationBuilder y la asigna a la propiedad Configuration.
            Configuration = builder.Build();
        }

        // Método para configurar servicios en la aplicación.
        public void ConfigureServices(IServiceCollection services)
        {
            // Agrega servicios necesarios para la configuración de opciones.
            services.AddOptions();

            // Agrega servicios de controladores MVC y configura las opciones de serialización JSON para ignorar ciclos de referencia.
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Agrega servicios de controladores MVC adicionales.
            services.AddControllers();


            services.AddTransient(typeof(ITransientWhoIAm), typeof(WhoIAm));
            services.AddScoped(typeof(IScopeWhoIAm), typeof(WhoIAm));
            services.AddSingleton(typeof(ISingletonWhoIAm), typeof(WhoIAm));
            services.AddTransient(typeof(IServiceWhoIAm), typeof(ServiceWhoIAm));

            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
            services.AddSingleton(typeof(ICreateUserServices), typeof(CreateUserServices));
            services.AddSingleton(typeof(IGetAllUserService), typeof(GetAllUserService));
            services.AddSingleton(typeof(IDeleteUserServices), typeof(DeleteUserService));
            services.AddSingleton(typeof(IGetUserService), typeof(GetUserService));
            services.AddSingleton(typeof(IUpdateEmailService), typeof(UpdateEmailService));


            // Agrega servicios de explorador de API de puntos de conexión.
            services.AddEndpointsApiExplorer();

            // Agrega servicios de generación de Swagger para la documentación de la API.
            services.AddSwaggerGen(c =>
            {
                // Agrega un requisito de seguridad para el esquema de autenticación de tipo Bearer.
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id ="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
            });

            // Agrega servicios de protección de datos.
            services.AddDataProtection();

            // Agrega políticas CORS predeterminadas que permiten cualquier origen, método y encabezado.
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // Método para configurar el middleware de la aplicación.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Agrega middleware Swagger para generar el punto de conexión JSON de Swagger y la interfaz de usuario de Swagger para la documentación de la API.
            app.UseSwagger();
            app.UseSwaggerUI();

            // Agrega middleware de enrutamiento.
            app.UseRouting();

            // Agrega middleware CORS para manejar las solicitudes de recursos de origen cruzado.
            app.UseCors();

            // Agrega middleware de autorización.
            app.UseAuthorization();

            // Configura los puntos finales de la aplicación para que coincidan con los controladores MVC.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
