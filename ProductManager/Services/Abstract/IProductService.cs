using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductManager.Models.Entity;

namespace ProductManager.Services.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetAsync(int Id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int Id);
        Task SaveAsync();
    }
}
