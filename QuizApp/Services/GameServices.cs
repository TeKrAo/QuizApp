using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly IQuestionsRepository _questionRepository;
        public GameService(IPlayersRepository playersRepository, IQuestionsRepository questionRepository)
        {
            _playersRepository = playersRepository;
            _questionRepository = questionRepository;
        }

        public Player SubmitQuiz(SubmitModel submitModel)
        {
            var player = _playersRepository.GetPlayerByName(submitModel.PlayerName);
            var round = new Round();
            var selectedAnswers = _questionRepository.GetAnswersByIds(submitModel.SelectedAnswerIds);
            var correctAnswers = selectedAnswers.Where(z => z.IsCorrect).Count();
            var score = (correctAnswers * 100) / selectedAnswers.Count;
            round.IsWon = score >= 70;
            var attempts = selectedAnswers.Select(x =>
                new Attempt
                {
                    AnswerId = x.Id,
                    IsCorrect = x.IsCorrect
                });
            round.Attempts.AddRange(attempts);
            player.Rounds.Add(round);

            if (round.IsWon) player.Wins++;
            player.HighestScore = player.HighestScore > score ? player.HighestScore : score;

            player = _playersRepository.UpdatePlayer(player);
            return player;
            throw new NotImplementedException();
        }

    }
}