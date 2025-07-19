using DAL.Data;
using DAL.Repositories.interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using BLL.Services.interfaces;
using BLL.Services;
//using BLL.Services;
//using BLL.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);
// DAL
builder.Services.AddScoped<IUserRepository, UserRepository>();

// BLL
builder.Services.AddScoped<IUserService, UserService>();
// Program.cs
builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DrinkOrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Inject Repository & Service cho User
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

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
