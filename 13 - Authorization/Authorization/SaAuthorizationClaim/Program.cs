using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaAuthorizationClaim.Auth;

namespace SaAuthorizationClaim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });
            
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddAuthentication("SaSecurityScheme")
                       .AddCookie("SaSecurityScheme", options =>
                       {
                           options.AccessDeniedPath = new PathString("/Security/Access");
                           options.LoginPath = new PathString("/Security/Login");
                       });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());

                options.AddPolicy("User", policy => policy.RequireClaim("User"));
                options.AddPolicy("Manager", policy => policy.RequireClaim("Manager"));
                options.AddPolicy("SiteAdmin", policy => policy.RequireClaim("SiteAdmin"));
                options.AddPolicy("SystemAdmin", policy => policy.RequireClaim("SystemAdmin"));
                //options.AddPolicy("HasExpenseCredit", policy => policy.RequireClaim("HasExpenseCredit"));
                options.AddPolicy("CanGiveBonus", policy => policy.RequireClaim("CanGiveBonus"));
                options.AddPolicy("HasExpenseCredit", policy => policy.Requirements.Add(new ManagerPayExpenseRequirement()));

                options.AddPolicy("AtLeast21", policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
            });

            builder.Services.AddScoped<IAuthorizationHandler, AdminRequirementHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, ManagerPayExpenseRequirementHandler>();

            builder.Services.AddRazorPages();
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter("Authenticated"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();

            }

            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}