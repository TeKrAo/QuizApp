using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionsRepository _questionRepository;
        public QuestionsController(IQuestionsRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        [HttpGet]
        public IActionResult GetQuestions()
        {
            var questions = _questionRepository.GetAllQuestions();
            return View("QuestionsList", questions);
        }

        [HttpGet]
        public IActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestion(Question question)
        {
            _questionRepository.AddQuestion(question);
            return RedirectToAction("AddQuestion");
        }

        [HttpPost]
        public IActionResult DeleteQuestion(int id)
        {
            _questionRepository.DeleteQuestion(id);
            return RedirectToAction("GetQuestions");
        }
    }
}
