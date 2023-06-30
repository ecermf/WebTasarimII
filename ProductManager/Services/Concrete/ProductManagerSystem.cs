using Microsoft.EntityFrameworkCore;
using ProductManager.Models.EfCore;
using ProductManager.Models.Entity;
using ProductManager.Services.Abstract;

namespace ProductManager.Services.Concrete
{
    public class ProductManagerSystem : IProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductManagerSystem(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Product product)
        {
            if(product!=null)
            {
                await _dbContext.AddAsync(product);
            }
            
        }

        public async Task DeleteAsync(int Id)
        {
            if(Id>0)
            {
                var hasProduct = await _dbContext.Products.AnyAsync(p=>p.Id==Id);
                if (hasProduct)
                {
                    var product = await _dbContext.Products.SingleOrDefaultAsync(p=>p.Id==Id);
                    _dbContext.Products.Remove(product);
                }
            }
        }

        public async Task<Product> GetAsync(int Id)
        {
            
                var hasProduct = await _dbContext.Products.AnyAsync(p => p.Id == Id);
                
               return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == Id);
                   
                
            

        }

        public async Task<List<Product>> GetProductsAsync()
        {
          return await _dbContext.Products.ToListAsync();
        }

        public async Task SaveAsync()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            if (product != null)
            {
                 await Task.Run(()=> { _dbContext.Update(product); });
            }
        }
    }
}
