namespace QuizApp.Models
{
    public class Input
    {
        public Input()
        {

        }
        public int ID { get; set; }

        public int RoundId { get; set; }

        public int AnswerId { get; set; }

        public bool IsCorrect { get; set; }
    }
}
