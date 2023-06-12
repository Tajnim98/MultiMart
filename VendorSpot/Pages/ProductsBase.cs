using Microsoft.AspNetCore.Components;
using ShopOnline.models.Dtos;
using VendorSpot.Pages;
using VendorSpot.Services.Contracts;

namespace VendorSpot.Pages
{
    public class ProductsBase :ComponentBase 
    {
        [Inject]
        public IProductService productService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await productService.GetItems();
        }

        protected IOrderedEnumerable<IGrouping<int, ProductDto>>GetGroupedProductsByCategory()
        {
            return from product in Products 
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }
        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDtos)
        {
            return groupedProductDtos.FirstOrDefault(pg => pg.CategoryId == groupedProductDtos.Key).CategoryName;
        }

        public string ErrorMessage { get; set; }
    }
}
