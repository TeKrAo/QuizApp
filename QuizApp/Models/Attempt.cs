﻿namespace QuizApp.Models
{
    public class Attempt
    {
        public int Id { get; set; }
        public int RoundId { get; set; }
        public int AnswerId { get; set; }
        public bool? IsCorrect { get; set; }
    }
}