using BLL.Interfaces;
using BLL.MappingProfiles;
using BLL.Services;
using DAL.Data;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.UoW;
using Microsoft.EntityFrameworkCore;
using Shop.MVC.MappingProfiles;
using Shop.MVC.ModelViews;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(ProductProfile), typeof(ProductMvProfile), typeof(ImageProfile), typeof(ImageMvProfile), typeof(FeedbackProfile), typeof(FeedbackMvProfile), typeof(CategoryProfile), typeof(CategoryMvProfile));

builder.Services.AddRazorPages();

//Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
//Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
