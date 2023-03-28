using Microsoft.AspNetCore.Components;
using OMS.Shared.DTO;

namespace OMS.Client.Pages.Order
{
    public partial class Index
    {
        bool IsLoading = true;
        bool ShowConfirmationOrder = false;
        private OrderDTO OrderToDelete { get; set; }
        List<OrderDTO> OrderList = new List<OrderDTO>();

        protected override async Task OnInitializedAsync()
        {
            OrderList = await OrderClientService.GetOrders();
            IsLoading = false;
        }

        void ShowOrder(long id)
        {
            NavigationManager.NavigateTo($"order-create/{id}");
        }

        void CreateNewOrder()
        {
            NavigationManager.NavigateTo("/order-create");
        }

        private void ShowConfirmationOrderDialog(OrderDTO model)
        {
            OrderToDelete = model;
            ShowConfirmationOrder = true;
        }

        private void HideConfirmationOrderDialog()
        {
            ShowConfirmationOrder = false;
        }

        async Task DeleteOrder(OrderDTO model)
        {
            try
            {
                HideConfirmationOrderDialog();
                await OrderClientService.DeleteOrder(model.Id);
                OrderList.Remove(model);
                StateHasChanged();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
