using DAL.EF;
using DAL.Repos;
using BLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add DbContext (DAL)
builder.Services.AddDbContext<PcBuildersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register BLL and DAL services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderRepo>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session expiration
    options.Cookie.HttpOnly = true; // Prevent JavaScript access
    options.Cookie.IsEssential = true; // GDPR compliance
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();