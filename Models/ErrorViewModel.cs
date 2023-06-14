namespace Time_Management.Models
{
    public class ErrorViewModel
    {

        //add prperties to the errorviewmodel class
        // (Troelsen and Japikse, 2017)
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}