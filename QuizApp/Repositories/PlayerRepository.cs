using QuizApp.Context;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly QuizAppDbContext context;

        public PlayersRepository(QuizAppDbContext context)
        {
            this.context = context;
        }

        public List<Player> GetAllPlayers()
        {
            return context.Players.ToList();
        }

        public Player AddPlayer(Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();
            return player;
        }

        public Player DeletePlayer(int id)
        {
            var player = context.Players.FirstOrDefault(x => x.ID == id);
            context.Players.Remove(player);
            context.SaveChanges();
            return player;
        }
    }
}
