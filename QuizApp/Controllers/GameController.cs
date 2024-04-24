using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;

namespace QuizApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IQuestionsRepository _questionRepository;
        public GameController(IGameService gameService, IQuestionsRepository questionRepository)
        {
            _gameService = gameService;
            _questionRepository = questionRepository;
        }
        [HttpGet]
        public IActionResult StartQuiz()
        {
            var questions = _questionRepository.GetAllQuestions();
            return View("Quiz", questions);
        }
        [HttpPost]
        public IActionResult SubmitQuiz(SubmitModel submitModel)
        {
            var player = _gameService.SubmitQuiz(submitModel);
            return RedirectToAction("StartQuiz");
        }
    }
}