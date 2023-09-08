using HiraganaApp.Data;
using HiraganaApp.Help;
using HiraganaApp.MVVM.Model;
using HiraganaApp.MVVM.View;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace HiraganaApp.MVVM.ViewModel
{
    public class QuizViewModel
    {
        public List<Letter> Letters = DataAccess.GetLetterList();
        public Letter letter;
        public int score;
        public int questionNumber;
        public int counter;
        public QuizPage quizPage;

        public RelayCommand MenuButtonCommand { get; private set; }
        public RelayCommand ExitButtonCommand { get; private set; }

        public QuizViewModel(QuizPage quizPage)
        {
            this.quizPage = quizPage;
            MenuButtonCommand = new RelayCommand(NavigateToMainPage);
            ExitButtonCommand = new RelayCommand(ExitApplication);
        }

        private void NavigateToMainPage()
        {
            if (Application.Current.MainWindow.FindName("MainFrame") is Frame frame)
            {
                frame.Navigate(new MainPage());
            }
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        public void StartQuiz()
        {
            var randomlist = QuizHelper.MixLetters(Letters);
            Letters = randomlist;
            if (questionNumber > Letters.Count)
            {
                RestartOuiz();
            }
            letter = Letters[questionNumber];
            quizPage.LetterTxtBlock.Text = letter.Symbol;
            SetVariants(letter);
        }

        public void NextQuestion()
        {
            if (questionNumber < Letters.Count && questionNumber != Letters.Count)
            {
                counter = questionNumber;
            }
            else
            {
                RestartOuiz();
            }
            letter = Letters[questionNumber];
            quizPage.LetterTxtBlock.Text = letter.Symbol;
            SetVariants(letter);
        }

        public void RestartOuiz()
        {
            score = 0;
            questionNumber = 0;
            counter = 0;
            StartQuiz();
        }


        public void ChekAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            if (senderButton.Content == letter.Transcription)
            {
                score++;
            }

            if (questionNumber < 0)
            {

                questionNumber = 0;
            }
            else
            {

                questionNumber++;
            }
            quizPage.scoreTxt.Text = "SCORE " + score + "/" + questionNumber;
            NextQuestion();
        }

        public void SetVariants(Letter letter)
        {
            var variants = QuizHelper.GetVariantsList(letter, Letters);

            quizPage.answButton1.Content = variants[0].Transcription;
            quizPage.answButton2.Content = variants[1].Transcription;
            quizPage.answButton3.Content = variants[2].Transcription;
            quizPage.answButton4.Content = variants[3].Transcription;
        }

    }
}
