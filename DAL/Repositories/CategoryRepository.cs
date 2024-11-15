using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ShopContext _shopContext;

    public CategoryRepository(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }
    
    public async Task CreateCategoryAsync(Category category)
    {
        await _shopContext.Categories.AddAsync(category);
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _shopContext.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var categories = await _shopContext.Categories.FirstOrDefaultAsync(p=>p.Id == id);
        return categories;
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _shopContext.Categories.FirstOrDefaultAsync(p => p.Id == id);
        _shopContext.Categories.Remove(category);
    }
}