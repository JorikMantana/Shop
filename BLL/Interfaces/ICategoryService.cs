using BLL.DTOs;
using DAL.Models;

namespace BLL.Interfaces;

public interface ICategoryService
{
    Task<Category> CreateCategoryAsync(CategoryDto categoryDto);
    Task<List<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task DeleteCategoryAsync(int id);
}