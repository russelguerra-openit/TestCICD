using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestCICD.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DataConnection");
var migrationsAssembly = typeof(DataContext).GetTypeInfo().Assembly.GetName().Name;
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly)), contextLifetime: ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
