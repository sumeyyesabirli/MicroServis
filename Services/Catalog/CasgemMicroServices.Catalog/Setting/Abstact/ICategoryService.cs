using CasgemMicroServices.Catalog.Dtos.CategoryDto;
using MicroservisShared.Dtos;

namespace CasgemMicroServices.Catalog.Setting.Abstact
{
    public interface ICategoryService 
    {
        Task<Response<List<ResultCategoryDto>>> GetCategoryListAsync();
        Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id);
        Task<Response<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto category);
        Task<Response<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto category);
        Task<Response<NoContent>> DeleteCategoryAsync(string id);
    }
}
