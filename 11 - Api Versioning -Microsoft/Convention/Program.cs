using Asp.Versioning;
using Convention.Controllers;
using Asp.Versioning.Conventions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddApiVersioning(
                    options =>
                    {
                        // reporting api versions will return the headers
                        // "api-supported-versions" and "api-deprecated-versions"
                        options.ReportApiVersions = true;
                        //options.ApiVersionReader = new HeaderApiVersionReader("api-version");

                    })
                .AddMvc(
     options =>
     {
         options.Conventions.Controller<SaleControllerV1>().HasApiVersion(new ApiVersion(1, 0));
         options.Conventions.Controller<SaleControllerV2>().HasApiVersion(new ApiVersion(2, 0));

     });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
