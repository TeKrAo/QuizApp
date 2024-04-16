using QuizApp.Models;

namespace QuizApp.Repositories
{
    public interface IPlayersRepository
    {
        List<Player> GetAllPlayers();
        Player AddPlayer(Player player);
        Player DeletePlayer(int id);
    }
}