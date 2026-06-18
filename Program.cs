using Microsoft.EntityFrameworkCore;
using Web_project_as.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JewelryContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("JewelryContextStr")));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=ShowAllProudect}/{id?}");

app.Run();
