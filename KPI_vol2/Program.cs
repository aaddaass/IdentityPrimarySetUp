using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;
using KPI_vol2.Repository;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHealthChecks();
builder.Services.AddRazorPages();
//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

//wstrzykiwanie zale�no�ci DI
builder.Services.AddScoped<IUzytkownik, RepoUzytkownik>();
builder.Services.AddScoped<IZdarzenia, RepoZdarzenia>();
builder.Services.AddScoped<IStatus, RepoStatus>();

builder.Services.AddScoped<IDepartaments, RepoDepartments>();
builder.Services.AddScoped<ICategories, RepoCategories>();
builder.Services.AddScoped<IPriorities, RepoPriorities>();
builder.Services.AddScoped<IWorkingAreas, RepoWorkingAreas>();
//builder.Services.AddScoped<IAssignerStatus, RepoAssignerStatus>();

builder.Services.AddScoped<IUzytkownik, RepoUzytkownik>();
builder.Services.AddScoped<IDevice, RepoDevice>();
builder.Services.AddScoped<IDeviceType, RepoDeviceType>();
builder.Services.AddScoped<ITelephone, RepoTelephonNo>();
builder.Services.AddScoped<IUrzyt_Device, RepoUzytkownikDevice>();
builder.Services.AddScoped<IZgloszenie, RepoZgloszenie>();
builder.Services.AddScoped<IComments, RepoComments>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
