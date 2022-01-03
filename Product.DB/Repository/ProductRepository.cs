using Microsoft.EntityFrameworkCore;
using Product.DB.Data;
using Product.DB.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.DB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _db;

        public ProductRepository(ProductDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Models.Product product)
        {
            try
            {
                _db.Add(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Models.Product>> GetProducts()
        {
            return await _db.Products.Include(p => p.Brand).OrderBy(o => o.ProductId).ToListAsync();
        }
    }
}
