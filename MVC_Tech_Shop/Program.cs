using Microsoft.EntityFrameworkCore;
using MVC_Tech_Shop.Data;

var builder = WebApplication.CreateBuilder(args);

string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TechShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection
builder.Services.AddDbContext<TechShopDbContext>(options => options.UseSqlServer(connectionStr));

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
