using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Data;
using SimApi.Operation;
using SimApi.Schema;

namespace SimApi.Service.Controllers;

[Route("simapi/v1/dappercategory")]
[ApiController]
public class DapperCategoryController : ControllerBase 
{
    private readonly ICategoryService _categoryService;
    
    public DapperCategoryController(ICategoryService categoryService) 
    {
        _categoryService = categoryService; 
    }
    
    [HttpGet] 
    public ApiResponse<List<CategoryResponse>> GetAll() 
    { 
        var categories = _categoryService.GetAll(); 
        return new ApiResponse<List<CategoryResponse>>(categories); 
    }

    [HttpGet("{id}")]
    public ApiResponse<CategoryResponse> GetById(int id) 
    {
        var category = _categoryService.GetById(id);
        return new ApiResponse<CategoryResponse>(category);
    }
    
    [HttpPost] 
    public IActionResult Insert([FromBody] CategoryRequest categoryRequest)
    {
        _categoryService.Insert(categoryRequest);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] CategoryRequest categoryRequest)
    {
        _categoryService.Update(id, categoryRequest);
        return Ok();
    }
    
    [HttpDelete("{id}")] 
    public IActionResult Delete(int id) 
    { 
        _categoryService.Delete(id); 
        return Ok();
    }
}