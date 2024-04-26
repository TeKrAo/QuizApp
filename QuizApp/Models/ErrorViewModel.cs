namespace QuizApp.Models
{
    public class ErrorViewModel
    {
        public string Comment { get; set; }
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}