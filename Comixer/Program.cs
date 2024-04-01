using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Comixer.Infrastructure;
using Comixer.Infrastructure.Data.Entities;
using Comixer.Core.Helpers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//Database
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedAccount");
    options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:RequireUniqueEmail");
})
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Api:CloudinarySettings"));

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "PublishComic", // New unique name
                        pattern: "Comics/Publish",
                        defaults: new { controller = "Comics", action = "Publish" });

app.MapControllerRoute(name: "Comics",
                 pattern: "Comics/{id?}",
                 defaults: new { controller = "Comics", action = "Comic" });

app.MapControllerRoute(name: "Chapter",
                 pattern: "Chapter/{id?}",
                 defaults: new { controller = "Chapter", action = "Chapter" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
