namespace QuizApp.Models
{
    public class SubmitModel
    {
        public string PlayerName { get; set; }
        public List<int> SelectedAnswerIds { get; set; }
    }
}