using Microsoft.AspNetCore.Components;
using OMS.Shared.DTO;

namespace OMS.Client.Pages.Order
{
    public partial class WindowComponent
    {

        [Parameter]
        public OrderDTO Order { get; set; }
        [Parameter]
        public WindowDTO Window { get; set; }
        private bool ShowWinodwConfirmation { get; set; } = false;
        bool IsLoadingWindow = false;

        [Parameter]
        public EventCallback<WindowDTO> OnRemoveWindow { get; set; }

        [Parameter]
        public EventCallback<SubElementDTO> OnAddSubElement { get; set; }

        [Parameter]
        public EventCallback<SubElementDTO> OnRemoveSubElement { get; set; }

        private void ShowConfirmationDialog()
        {
            ShowWinodwConfirmation = true;
        }

        private void HideConfirmationDialog()
        {
            ShowWinodwConfirmation = false;
        }

        private void AddSubElement()
        {
            //IsLoadingWindow = true;
            var subElement = new SubElementDTO();
            Window.SubElements.Add(subElement);
            OnAddSubElement.InvokeAsync(subElement);
            //IsLoadingWindow = false;
        }

        private async void RemoveWindow()
        {
            HideConfirmationDialog();
            //IsLoadingWindow = true;
            if (Window.Id > 0)
            {
                await OrderClientService.DeleteWindow(Window.Id);
            }
            await OnRemoveWindow.InvokeAsync(Window);
           
        }

        private async void RemoveSubElement(SubElementDTO subElement)
        {
           
            if (subElement.Id > 0)
            {
                await OrderClientService.DeleteSubElement(subElement.Id);

                var window = Order.Windows.FirstOrDefault(w => w.Id == Window.Id);
                if (window != null)
                {
                    window.SubElements.Remove(subElement);
                }
            }
            else
            {
                Order.Windows.ElementAt(0).SubElements.Remove(subElement);
            }

            Window.SubElements.Remove(subElement);
            await OnRemoveSubElement.InvokeAsync(subElement);
        
        }
    }
}
