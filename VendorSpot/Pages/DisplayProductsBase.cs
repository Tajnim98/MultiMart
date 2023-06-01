
using Microsoft.AspNetCore.Components;
using ShopOnline.models.Dtos;

namespace VendorSpot.Pages
{
    public class DisplayProductsBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
