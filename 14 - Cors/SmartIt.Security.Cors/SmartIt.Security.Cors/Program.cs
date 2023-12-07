
internal class Program
{
    private static void Mainb(string[] args) // Enabling CORS basic
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors();
        // services.AddResponseCaching();  

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors(builder => builder.WithOrigins("http://localhost:44369")
        .SetIsOriginAllowed((host) => true));


        app.MapControllers();
        app.Run();
    }

    private static void MainP(string[] args) // Enabling CORS Policy
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(p => p.AddPolicy("SmartIt", build =>
            {
                build.WithOrigins("https://localhost:44337", "http://127.0.0.1:5500")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }
        ));
        builder.Services.AddCors();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("SmartIt");

        app.MapControllers();
        app.Run();
    }

    private static void MainM(string[] args) // Enabling CORS in MVC
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(p => p.AddPolicy("SmartIt", build =>
        {
            build.WithOrigins("https://localhost:44337", "http://127.0.0.1:5500")
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
        ));
        builder.Services.AddCors();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("SmartIt");

        app.MapControllers();
        app.Run();
    }

    private static void Main(string[] args) // Enabling CORS in Globally
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(p => p.AddPolicy("SmartIt", build =>
        {
            build.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
        ));
        builder.Services.AddCors();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("SmartIt");

        app.MapControllers();
        app.Run();
    }
}