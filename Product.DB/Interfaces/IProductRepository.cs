using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.DB.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<Models.Product>> GetProducts();
        Task<bool> Create(Models.Product product);
    }
}
