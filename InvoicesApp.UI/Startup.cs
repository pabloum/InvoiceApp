using InvoiceApp.Business;
using InvoiceApp.Domain;
using InvoiceApp.Persistence;

namespace InvoiceApp.UI;

public class Startup
{
    public readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void AddServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        
        services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(_configuration.GetConnectionString("InvoiceDataBase") ?? string.Empty));
        
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();

        services.AddTransient<IInvoiceService, InvoiceService>();
    }

    public void StartApp(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}