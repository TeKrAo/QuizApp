using QuizApp.Models;

namespace QuizApp.Services
{
    public interface IGameService
    {
        Player SubmitQuiz(SubmitModel submitModel);
    }
}