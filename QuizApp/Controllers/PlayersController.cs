using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayersRepository _playersRepository;
        public PlayersController(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }
        [HttpGet]
        public IActionResult GetPlayers()
        {
            var players = _playersRepository.GetAllPlayers();
            return View("PlayersList", players);
        }
        [HttpGet]
        public IActionResult AddPlayer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPlayer(Player player)
        {
            _playersRepository.AddPlayer(player);
            return RedirectToAction("AddPlayer");
        }

        [HttpPost]
        public IActionResult DeletePlayer(int id)
        {
            _playersRepository.DeletePlayer(id);
            return RedirectToAction("GetPlayers");
        }
    }
}