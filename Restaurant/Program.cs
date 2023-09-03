using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Restaurant.DAL;
using SharedDI;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Configuration.AddJsonFile("local.json");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection, b => b.MigrationsAssembly("Restaurant")));

builder.Services.AddAuthentication(config => {
    config.DefaultScheme = "Cookie";
    config.DefaultChallengeScheme = "oidc";
})
               .AddCookie("Cookie")
               .AddOpenIdConnect("oidc", config => {
                   config.Authority = "https://localhost:10001/";
                   config.ClientId = "client_id_mvc";
                   config.ClientSecret = "client_secret_mvc";
                   config.SaveTokens = true;
                   config.ResponseType = "code";
                   config.SignedOutCallbackPath = "/Home/Index";

                   config.GetClaimsFromUserInfoEndpoint = true;

                   // configure scope
                   config.Scope.Clear();
                   config.Scope.Add("openid");
                   config.Scope.Add("rc.scope");
                   config.Scope.Add("offline_access");

               });
builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "IdentityServer.Cookie"; 
    config.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    config.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
});


builder.Services.AddHttpClient();
SharedContainer.RegisterServices(builder.Services);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();
builder.Services.AddAuthentication();
var assembly = typeof(Program).Assembly.GetName().Name;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    SeedData.Initialize(serviceProvider);
}

app.Run();
