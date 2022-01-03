using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Product.DB.Interfaces;

namespace Product.App.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;

        public CreateModel(IProductRepository productRepository, IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        [BindProperty]
        public DB.Models.Product Product { get; set; }
        public List<DB.Models.Brand> Brands { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Brands = new List<DB.Models.Brand>();
            Brands.AddRange(await _brandRepository.GetBrands());

            ViewData["ListofBrands"] = Brands;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productRepository.Create(Product);

            return RedirectToPage("./Index");
        }
    }
}
