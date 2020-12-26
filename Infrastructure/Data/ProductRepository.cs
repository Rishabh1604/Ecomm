using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await this.storeContext.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await this.storeContext.Products.ToListAsync();
        }
    }
}