using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options=>
{
    options.Cookie.Name = "StoreApp.Session";
    options.IOTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

//builder.Services.AddSingleton<Cart>();
builder.Services.AddScoped<Cart>(c=> SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName : "Admin",
        pattern: "Admin/{Controller=Dashboard}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{Controller=Home}/{action=Index}/{id?}"
        );       
    
    endpoints.MapRazorPages();
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();
