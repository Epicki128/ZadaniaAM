using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quiz.Services;
using Quiz.Models;
using System.Collections.ObjectModel;

namespace Quiz.ViewModels
{
    public partial class QuestionsViewModel : ObservableObject
    {
        private readonly IFileService _closedQuestionsService;
        public QuestionsViewModel(IFileService closedQuestionsService) => _closedQuestionsService = closedQuestionsService;

        private ObservableCollection<ClosedQuestionModel> Questions = new();

        [ObservableProperty] private string _imageSrc;
        [ObservableProperty] private string _question;
        [ObservableProperty] private int _questionNumber = 0;
        [ObservableProperty] private string _answerA;
        [ObservableProperty] private string _answerB;
        [ObservableProperty] private string _answerC;
        [ObservableProperty] private Answer _correctAnswer;
        [ObservableProperty] private Answer? _selectedAnswer;
        [ObservableProperty] private string _isCorrect = "";


        partial void OnSelectedAnswerChanged(Answer? value)
        {
            Console.Write("abc");
            if (value.Equals(CorrectAnswer))
            {
                IsCorrect = "Odpowiedź jest poprawna!";
            }
            else
            {
                IsCorrect = "Odpowiedź jest niepoprawna";
            }
        }


        [RelayCommand]
        void NextQuestion()
        {
            if (QuestionNumber < Questions.Count - 1)
            {
                QuestionNumber++;
            }
            else
            {
                QuestionNumber = 0;
            }
            SelectedAnswer = null;
            IsCorrect = string.Empty;
            LoadQuestions();
        }

        void LoadQuestions()
        {
            var q = Questions[QuestionNumber];
            ImageSrc = q.imageSrc;
            Question = q.question;
            AnswerA = q.answerA;
            AnswerB = q.answerB;
            AnswerC = q.answerC;
            CorrectAnswer = Enum.Parse<Answer>(Questions[QuestionNumber].correctAnswer.ToString());
        }

        [RelayCommand]
        async Task GetQuestions()
        {
            var result = await _closedQuestionsService.GetAsync<List<ClosedQuestionModel>>("questions.json");
            Questions = new ObservableCollection<ClosedQuestionModel>(result ?? []);
            LoadQuestions();
        }
    }
}
