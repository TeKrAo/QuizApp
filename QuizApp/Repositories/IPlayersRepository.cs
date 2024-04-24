using QuizApp.Models;

namespace QuizApp.Repositories
{
    public interface IPlayersRepository
    {
        List<Player> GetAllPlayers();
        Player GetPlayerByName(string playerName);
        Player GetPlayerById(int id);
        Player UpdatePlayer(Player player);
        Player AddPlayer(Player player);
        Player DeletePlayer(int id);
    }
}