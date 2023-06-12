using Microsoft.AspNetCore.Components;
using ShopOnline.models.Dtos;
using VendorSpot.Services;
using VendorSpot.Services.Contracts;

namespace VendorSpot.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
                navigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception)
            {

            }
        }
    }
}
