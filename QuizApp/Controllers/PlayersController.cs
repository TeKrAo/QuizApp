using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;
using System.Diagnostics;

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
            try
            {
                _playersRepository.AddPlayer(player);
            }
            catch (ArgumentNullException ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Comment = ex.Message
                };
                return View("Error", errorViewModel);
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Comment = ex.Message
                };
                return View("Error", errorViewModel);
            }
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