using Microsoft.EntityFrameworkCore;
using Product.DB.Data;
using Product.DB.Interfaces;
using Product.DB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.DB.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ProductDbContext _db;

        public BrandRepository(ProductDbContext db)
        {
            _db = db;
        }

        public async Task<IList<Brand>> GetBrands()
        {
            return await _db.Brands.OrderBy(o => o.BrandId).ToListAsync();
        }
    }
}
