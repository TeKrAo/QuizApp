using QuizApp.Models;

namespace QuizApp.Repositories
{
    public interface IQuestionsRepository
    {
        List<Question> GetAllQuestions();
        Question AddQuestion(Question question);
        Question DeleteQuestion(int id);
    }
}
