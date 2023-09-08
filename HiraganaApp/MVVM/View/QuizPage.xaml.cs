using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using HiraganaApp.Data;
using HiraganaApp.Help;
using HiraganaApp.MVVM.Model;
using HiraganaApp.MVVM.ViewModel;
using Microsoft.EntityFrameworkCore.Storage;
using static System.Formats.Asn1.AsnWriter;

namespace HiraganaApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page
    {
        private QuizViewModel _viewModel;    
        public QuizPage()
        {
            InitializeComponent();
            _viewModel = new QuizViewModel(this);
            DataContext = _viewModel;
            _viewModel.StartQuiz();
            _viewModel.NextQuestion();
        }
        public void ChekAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            if (senderButton.Content == _viewModel.letter.Transcription)
            {
                _viewModel.score++;
            }

            if (_viewModel.questionNumber < 0)
            {

                _viewModel.questionNumber = 0;
            }
            else
            {

                _viewModel.questionNumber++;
            }
            _viewModel.quizPage.scoreTxt.Text = "SCORE " + _viewModel.score + "/" + _viewModel.questionNumber;
            _viewModel.NextQuestion();
        }
    }
}
