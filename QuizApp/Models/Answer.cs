namespace QuizApp.Models
{
    public class Answer
    {
        public Answer()
        {
            IsCorrect = false;
        }
        public int Id { get; set; }
        public string? AnswerText { get; set; }
        public bool? IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
 