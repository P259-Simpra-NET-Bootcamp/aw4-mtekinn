using SimApi.Data;
using SimApi.Data.Repository;
using SimApi.Schema;

namespace SimApi.Operation;

public class CategoryService : ICategoryService
{
    private readonly IDapperRepository<Category> _categoryRepository;

    public CategoryService(IDapperRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public List<CategoryResponse> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        return categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name }).ToList();
    }

    public CategoryResponse GetById(int id)
    {
        var category = _categoryRepository.GetById(id);
        return new CategoryResponse { Id = category.Id, Name = category.Name };
    }

    public void Insert(CategoryRequest categoryRequest)
    {
        var category = new Category { Name = categoryRequest.Name };
        _categoryRepository.Insert(category);
    }

    public void Update(int request, CategoryRequest categoryRequest)
    {
        var category = _categoryRepository.GetById(categoryRequest.Id);
        category.Name = categoryRequest.Name;
        _categoryRepository.Update(category);
    }

    public void Delete(int id)
    {
        _categoryRepository.DeleteById(id);
    }
}