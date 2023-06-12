using SimApi.Base;
using SimApi.Schema;

namespace SimApi.Operation;

public interface ICategoryService
{
    List<CategoryResponse> GetAll();
    CategoryResponse GetById(int id);
    void Insert(CategoryRequest categoryRequest);
    void Update(int request, CategoryRequest categoryRequest);
    void Delete(int id);
}