using Microsoft.AspNetCore.Components;
using OMS.Client.Services.OrderClient;
using OMS.Shared.DTO;

namespace OMS.Client.Pages.Order
{
    public  partial class SubElementComponent
    {
        [Parameter]
        public SubElementDTO SubElement { get; set; }

        [Parameter]
        public EventCallback<SubElementDTO> OnRemoveSubElement { get; set; }

       
        private bool ShowConfirmationSub { get; set; } = false;
        bool IsLoadingSub = false;

        private void RemoveSubElement()
        {
         
            ShowConfirmationSub = false;
            OnRemoveSubElement.InvokeAsync(SubElement);
           
        }

        private void ShowConfirmationDialog()
        {
            ShowConfirmationSub = true;
        }

        private void HideConfirmationDialog()
        {
            ShowConfirmationSub = false;
        }
    }
}
