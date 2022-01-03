using Microsoft.AspNetCore.Mvc.RazorPages;
using Product.DB.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.App.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<DB.Models.Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _productRepository.GetProducts();
        }
    }
}
