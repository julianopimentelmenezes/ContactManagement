namespace ContactManagement.Common.ViewModels
{
    /// <summary>
    /// This class is responsible to have the error page fields
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Message { get; set; }
    }
}
