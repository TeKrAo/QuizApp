using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Context;
using QuizApp.Models;
using System.Numerics;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            if (String.IsNullOrEmpty(player.Name))
                throw new ArgumentNullException("Player can't be empty");
            if (GetPlayerByName(player.Name) != null)
                throw new Exception("ALREADY EXISTS");
                
                
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
