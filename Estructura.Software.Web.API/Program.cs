using Estructura.Software.Web.API;

// Crea un constructor de aplicaciones web utilizando la API de inicio de ASP.NET Core y pasa los argumentos de la línea de comandos.
var builder = WebApplication.CreateBuilder(args);

// Crea una instancia de la clase Startup pasando la configuración del constructor de la aplicación web.
var startup = new Startup(builder.Configuration);

// Configura los servicios de la aplicación utilizando el método ConfigureServices de la clase Startup.
startup.ConfigureServices(builder.Services);

// Construye la aplicación web utilizando el constructor de la aplicación web.
var app = builder.Build();

// Configura la aplicación web utilizando el método Configure de la clase Startup y el entorno de la aplicación.
startup.Configure(app, app.Environment);

// Ejecuta la aplicación web.
app.Run();
