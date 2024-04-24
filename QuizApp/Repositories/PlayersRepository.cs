using Microsoft.EntityFrameworkCore;
using QuizApp.Context;
using QuizApp.Models;
using System.Numerics;

namespace QuizApp.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly QuizAppDbContext _context;
        public PlayersRepository(QuizAppDbContext context)
        {
            _context = context;
        }
        public List<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }
        public Player GetPlayerByName(string playerName)
        {
            return _context.Players.Include("Rounds").FirstOrDefault(p => p.Name == playerName);
        }
        public Player GetPlayerById(int id)
        {
            return _context.Players.Include("Rounds").FirstOrDefault(p => p.ID == id);
        }
        public Player AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return player;
        }
        public Player UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
            var updatedPlayer = GetPlayerById(player.ID);

            return updatedPlayer;
        }
        public Player DeletePlayer(int id)
        {
            var player = _context.Players.FirstOrDefault(x => x.ID == id);
            _context.Players.Remove(player);
            _context.SaveChanges();
            return player;
        }
    }
}
