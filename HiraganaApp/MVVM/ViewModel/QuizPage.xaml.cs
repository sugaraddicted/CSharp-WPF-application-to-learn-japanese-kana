using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using HiraganaApp.Data;
using HiraganaApp.Help;
using HiraganaApp.MVVM.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace HiraganaApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page
    {

        public List<Letter> Letters { get; set; } = DataAccess.GetLetterList();

        public Letter _letter { get; set; }  

        public int _score { get; set; }   

        public int _questionNumber { get; set; } 

        public int _counter { get; set; }
       
        public QuizPage()
        {
            
            InitializeComponent();
            StartQuiz();
            NextQuestion();
            
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        public void StartQuiz()
        {
            var randomlist = QuizHelper.MixLetters(Letters);
            Letters = randomlist;
            if (_questionNumber > Letters.Count)
            {
                RestartOuiz();
            }
            _letter = Letters[_questionNumber];
            LetterTxtBlock.Text = _letter.Symbol;
            SetVariants(_letter);
        }

        public void NextQuestion()
        {
            if (_questionNumber < Letters.Count && _questionNumber != Letters.Count){
                _counter = _questionNumber;
            }
            else{
                RestartOuiz();
            }
            _letter = Letters[_questionNumber];
            LetterTxtBlock.Text = _letter.Symbol;
            SetVariants(_letter);
         }

        public void RestartOuiz()
        {
            _score = 0;
            _questionNumber = 0;
            _counter = 0;
            StartQuiz();
         }


        public void ChekAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            if(senderButton.Content == _letter.Transcription){
                _score++;
            }

            if(_questionNumber < 0){

                _questionNumber = 0;
            }
            else {

                _questionNumber++;
            }
            scoreTxt.Text = "SCORE " + _score + "/" + _questionNumber;
            NextQuestion();
        }

        public void SetVariants(Letter letter)
        {
            var variants = QuizHelper.GetVariantsList(letter, Letters);

            answButton1.Content = variants[0].Transcription;
            answButton2.Content = variants[1].Transcription;
            answButton3.Content = variants[2].Transcription;
            answButton4.Content = variants[3].Transcription;
        }
        
    }
}
