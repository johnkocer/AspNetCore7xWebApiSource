var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "gotoOne",
       pattern: "one",
       defaults: new { controller = "Home", action = "ViewOne" });

    endpoints.MapControllerRoute(
       name: "gotoTwo",
       pattern: "two/{id?}",
       defaults: new { controller = "Home", action = "ViewTwo" });

    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=index}/{id?}");
});

app.Run();
