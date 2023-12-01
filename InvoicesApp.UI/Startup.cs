using InvoiceApp.Business;
using InvoiceApp.Persistence;
using Microsoft.Data.SqlClient;

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
        
        // Add SqlConnection and UnitOfWork
        // services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(_configuration));
        services.AddScoped(provider => new SqlConnection(_configuration.GetConnectionString("InvoiceDataBase")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // Add Repositories to container
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IInvoiceRepository, InvoiceRepository>();

        // Add Services to container
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