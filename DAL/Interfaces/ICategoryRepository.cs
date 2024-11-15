using DAL.Models;

namespace DAL.Interfaces;

public interface ICategoryRepository
{
    Task CreateCategoryAsync(Category category);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task DeleteCategoryAsync(int id);
}