using Microsoft.EntityFrameworkCore;
using QuizApp.Context;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly QuizAppDbContext _context;
        public QuestionsRepository(QuizAppDbContext context)
        {
            _context = context;
        }
        public List<Question> GetAllQuestions()
        {
           return _context.Questions.Include("Answers").ToList();
        }

        public Question AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return question;
        }

        public Question DeleteQuestion(int id)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == id);
            _context.Questions.Remove(question);
            _context.SaveChanges();
            return question;
        }
    }
}
