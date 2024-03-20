using Estructura.Software.Web.API;

// Crea un constructor de aplicaciones web utilizando la API de inicio de ASP.NET Core y pasa los argumentos de la l�nea de comandos.
var builder = WebApplication.CreateBuilder(args);

// Crea una instancia de la clase Startup pasando la configuraci�n del constructor de la aplicaci�n web.
var startup = new Startup(builder.Configuration);

// Configura los servicios de la aplicaci�n utilizando el m�todo ConfigureServices de la clase Startup.
startup.ConfigureServices(builder.Services);

// Construye la aplicaci�n web utilizando el constructor de la aplicaci�n web.
var app = builder.Build();

// Configura la aplicaci�n web utilizando el m�todo Configure de la clase Startup y el entorno de la aplicaci�n.
startup.Configure(app, app.Environment);

// Ejecuta la aplicaci�n web.
app.Run();
