using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.Helpers;
using ExpenseManagement.Infra;
using ExpenseManagement.Infra.Contexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(5,7,37));
builder.Services.AddDbContext<ExpenseManagementContext>(options =>
    options.UseMySql(connectionString, serverVersion, b => b.MigrationsAssembly("ExpenseManagement.Server")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(
    //options => options.SignIn.RequireConfirmedAccount = true
    )
    .AddEntityFrameworkStores<ExpenseManagementContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<User, ExpenseManagementContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddRazorPages();
builder.Services.AddControllers(options => { options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true; });

DependenciesInjector.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

ConfigHelper.SetEnvironment(app.Environment);

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
