using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();




app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<br/>Middleware 1-------------------><br/>");
    // Calls next middleware in pipeline
    await next.Invoke();
});
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 2-------------------><br/>");
    // Calls next middleware in pipeline
    await next.Invoke();
});
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 3-------------------><br/>");
    // Calls next middleware in pipeline
    await next.Invoke();
});
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 4-------------------><br/>");
    // Calls next middleware in pipeline
    await next.Invoke();
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();
