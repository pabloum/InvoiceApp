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
        
        services.AddScoped(provider => new SqlConnection(_configuration.GetConnectionString("InvoiceDataBase")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IInvoiceService, InvoiceService>();
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