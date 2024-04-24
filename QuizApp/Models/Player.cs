namespace QuizApp.Models
{
    public class Player
    {
        public Player()
        {
            HighestScore = 0;
            Wins = 0;
            Rounds = new List<Round>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int HighestScore { get; set; }
        public int Wins { get; set; }
        public List<Round> Rounds { get; set; }
    }
}
