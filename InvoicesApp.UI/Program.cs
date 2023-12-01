var builder = WebApplication.CreateBuilder(args);

var startup = new InvoiceApp.UI.Startup(builder.Configuration);
startup.AddServices(builder.Services);
var app = builder.Build();
startup.StartApp(app);