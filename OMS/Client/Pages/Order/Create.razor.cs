using Microsoft.AspNetCore.Components;
using OMS.Shared.DTO;

namespace OMS.Client.Pages.Order
{
    public partial class Create
    {
        [Parameter]
        public int? Id { get; set; }

        private bool IsLoading = true;
        private OrderDTO Order { get; set; } = new OrderDTO();

        private string btnText = string.Empty;
        private bool showConfirmationDialog = false;
        

        protected override async Task OnInitializedAsync()
        {
            btnText = Id == null ? "Save Order" : "Update Order";
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != null)
            {
                Order = await OrderClientService.GetSingleOrders((int)Id);
            }
            IsLoading = false;
        }

        private void AddWindow()
        {
            var window = new WindowDTO();
            Order.Windows.Add(window);
        }

        private void RemoveWindow(WindowDTO window)
        {
            Order.Windows.Remove(window);
        }

        private void AddSubElement(SubElementDTO subElement)
        {
            StateHasChanged();
        }

        private void RemoveSubElement(SubElementDTO subElement)
        {
            StateHasChanged();
        }

        private async void HandleValidSubmit()
        {
            IsLoading = true;
            if (Id == null)
            {
                try
                {
                    await OrderClientService.CreateOrder(Order);
                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                try
                {
                    await OrderClientService.UpdateOrder(Order);
            
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            IsLoading = false;
        }

        private async Task Close()
        {
            IsLoading = true;
            await OrderClientService.OrderIndex("index");
            IsLoading = false;
        }
    }
}