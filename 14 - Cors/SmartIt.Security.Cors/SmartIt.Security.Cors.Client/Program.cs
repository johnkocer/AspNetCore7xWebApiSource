
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

//builder.Services.AddApiVersioning(
//                    options =>
//                    {
//                        // reporting api versions will return the headers
//                        // "api-supported-versions" and "api-deprecated-versions"
//                        options.ReportApiVersions = true;
//                        //options.ApiVersionReader = new HeaderApiVersionReader("api-version");

//                    })
//                .AddMvc(
//     options =>
//     {
//         options.Conventions.Controller<SaleControllerV1>().HasApiVersion(new ApiVersion(1, 0));
//         options.Conventions.Controller<SaleControllerV2>().HasApiVersion(new ApiVersion(2, 0));

//     });

var app = builder.Build();
app.Use((ctx, next) =>
{
    ctx.Response.Headers["Access-Control-Allow-Origin"] = "https://localhost:44386";
    return next();
}
);

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddRazorPages();
//    services.AddControllers();
//}

//// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
//    if (env.IsDevelopment())
//    {
//        app.UseDeveloperExceptionPage();
//    }

//    app.UseStaticFiles();
//    app.UseRouting();

//    app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapControllerRoute(
//                  name: "default",
//                  pattern: "{controller=Home}/{action=Index}/{id?}");
//        endpoints.MapRazorPages();
//    });

