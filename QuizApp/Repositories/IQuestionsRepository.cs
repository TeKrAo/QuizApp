using QuizApp.Models;

namespace QuizApp.Repositories
{
    public interface IQuestionsRepository
    {
        List<Question> GetAllQuestions();
        List<Answer> GetAnswersByIds(List<int> ids);
        Question AddQuestion(Question question);
        Question DeleteQuestion(int id);
    }
}