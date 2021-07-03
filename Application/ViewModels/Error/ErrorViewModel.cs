using System;

namespace Application.ViewModels
{
    public class ErrorViewModel : Error
    {
        public ErrorViewModel()
        {
            Show();
        }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public override void Show()
        {
            Message = "ErrorViewModel";
            num = 0;
        }
    }
}
