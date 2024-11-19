using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.UoW;

namespace BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Category> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _unitOfWork.Categories.CreateCategoryAsync(category);
        await _unitOfWork.SaveChanges();
        
        return category;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllCategoriesAsync();
        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetCategoryByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public Task DeleteCategoryAsync(int id)
    {
        return _unitOfWork.Categories.DeleteCategoryAsync(id);
    }
}