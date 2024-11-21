using BLL.Interfaces;
using BLL.MappingProfiles;
using BLL.Services;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DAL.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.MVC.MappingProfiles;
using Shop.MVC.ModelViews;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<IdentityShopContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;               // Не требуется как минимум одна цифра
        options.Password.RequireLowercase = false;           // Не требуется как минимум одна строчная буква
        options.Password.RequireUppercase = false;           // Не требуется как минимум одна заглавная буква
        options.Password.RequireNonAlphanumeric = false;     // Не требуется как минимум один специальный символ
        options.Password.RequiredLength = 0;                  // Минимальная длина пароля (0 означает отсутствие требований)
        options.Password.RequiredUniqueChars = 0;             // Количество уникальных символов в пароле
    })
    .AddEntityFrameworkStores<IdentityShopContext>();





builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(ProductProfile), typeof(ProductMvProfile), typeof(ImageProfile), typeof(ImageMvProfile), typeof(FeedbackProfile), typeof(FeedbackMvProfile), typeof(CategoryProfile), typeof(CategoryMvProfile), typeof(UserProfile), typeof(UserMvProfile), typeof(ImageProfile), typeof(ImageMvProfile), typeof(OrderMvProfile), typeof(OrderProfile));

builder.Services.AddRazorPages();

//Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
//Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
