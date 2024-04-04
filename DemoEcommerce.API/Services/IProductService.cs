using DEmoECommerce.Library.Models;
using DEmoECommerce.Library.Responses;

namespace DemoEcommerce.API.Services
{
    public interface IProductService
    {
        Task<ServiceResponse> AddProductAsync(Product product);
        Task<ServiceResponse> UpdateProductAsync(Product product);
        Task<ServiceResponse> DeleteProductAsync(int Id);
        Task<Product> GetProductByIdAsync(int Id);
        Task<List<Product>> GetProductsAsync();
    }
}
