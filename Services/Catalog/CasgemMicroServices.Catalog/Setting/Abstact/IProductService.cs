using CasgemMicroServices.Catalog.Dtos.ProductDto;
using MicroservisShared.Dtos;

namespace CasgemMicroServices.Catalog.Setting.Abstact
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDto>>> GetProductListAsync();
        Task<Response<ResultProductDto>> GetProductByIdAsync(string id);
        Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto product);
        Task<Response<UpdateProductDto>> UpdateProductAsync(UpdateProductDto product);
        Task<Response<NoContent>> DeleteProductAsync(string id);
    }
}
