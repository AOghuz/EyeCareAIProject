using BusinnessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EyeCareAIProject.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<Context>();

// Identity & Custom Validator
builder.Services.CustomValidator();
builder.Services
    .AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>()
    .AddDefaultTokenProviders();

// Services & Extensions
builder.Services.ContainerDependencies();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient();

// MVC ve Fluent Validation
builder.Services.AddControllersWithViews().AddFluentValidation();

// Global Authorization Policy
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

// Cookie Ayarları
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Login/AccessDenied";
    options.LoginPath = "/Login/SignIn";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
});

// SecurityStamp Validation Ayarları (Opsiyonel ama önerilir)
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero;
});

var app = builder.Build();

// Middleware Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/ErrorPage", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

// Doğru Middleware sıralaması
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Route Ayarları
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// İlk çalışmada rollerin kontrolünü ve eklenmesini sağlar
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

    string[] roleNames = { "Admin", "Doctor", "Patient", "Secretary", "Editor" };

    foreach (var role in roleNames)
    {
        var roleExists = await roleManager.RoleExistsAsync(role);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new AppRole { Name = role });
        }
    }
}

app.Run();
