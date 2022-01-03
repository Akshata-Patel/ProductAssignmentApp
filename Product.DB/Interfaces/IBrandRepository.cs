using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.DB.Interfaces
{
    public interface IBrandRepository
    {
        Task<IList<Models.Brand>> GetBrands();
    }
}
