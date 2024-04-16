namespace QuizApp.Models
{
    public class Round
    {
        public Round()
        {
            Score = 0;
            Attempts = new List<Attempt>();
        }
        public int ID { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public List<Attempt> Attempts { get; set; }
    }
}
