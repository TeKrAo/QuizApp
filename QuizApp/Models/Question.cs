namespace QuizApp.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
 