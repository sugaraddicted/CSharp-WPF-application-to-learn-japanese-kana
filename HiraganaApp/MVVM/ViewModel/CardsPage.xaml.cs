using HiraganaApp.Data;
using HiraganaApp.Help;
using HiraganaApp.MVVM.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace HiraganaApp.MVVM.View
{
    
    public partial class CardsPage : Page
    {
        public List<Letter> Letters { get; set; } = DataAccess.GetLetterList();

        public List<Letter> _mixedLettersList { get; set; }

        public int _questionNumber { get; set; } = 0;

        public CardsPage()
        {
            InitializeComponent();
            Start();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        public void Start()
        {
            _questionNumber = 0;
            _mixedLettersList = QuizHelper.MixLetters(Letters);
            SetSymbolSide();
           
            LeftBorder1.Background = page.Background;
            LeftBorder2.Background = page.Background;

            NextTxt.Text = _mixedLettersList[_questionNumber + 1].Symbol;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
             _questionNumber++;
            SetSymbolSide();

            SetPreviousCard();

            if(_questionNumber >= _mixedLettersList.Count - 1)
            {
                _questionNumber = 0;
            }
            
            NextTxt.Text = _mixedLettersList[_questionNumber + 1].Symbol;
        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            if (SymbolTxt.Text == _mixedLettersList[_questionNumber].Transcription)
            {
                SetSymbolSide();
            }
            else
            {
                SetTranscriptionSide();
            }
        }


        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (_questionNumber > 0)
            {
                _questionNumber--;

                SetSymbolSide();
                NextTxt.Text = _mixedLettersList[_questionNumber + 1].Symbol;
            }
            else if(_questionNumber == 0)
            {
                SetSymbolSide();
                NextTxt.Text = _mixedLettersList[_questionNumber + 1].Symbol;
            }
            SetPreviousCard();
        }

        public void SetPreviousCard()
        {
            if (_questionNumber > 0)
            {
                LeftBorder1.Background = RightBorder1.Background;
                LeftBorder2.Background = RightBorder2.Background;
                PrevTxt.Foreground = RightBorder1.Background;
                PrevTxt.Text = _mixedLettersList[_questionNumber - 1].Symbol;
            }
            else
            {
                LeftBorder1.Background = page.Background;
                LeftBorder2.Background = page.Background;
                PrevTxt.Foreground = page.Background;

            }
        }

        public void SetSymbolSide()
        {
            CardBord1.Background = RightBorder1.Background;
            CardBord2.Background = RightBorder2.Background;
            SymbolTxt.Foreground = CardBord1.Background;

            SymbolTxt.FontSize = 130;

            SymbolTxt.Text = _mixedLettersList[_questionNumber].Symbol;
        }

        public void SetTranscriptionSide()
        {
            CardBord1.Background = RightBorder2.Background;
            CardBord2.Background = RightBorder1.Background;
            SymbolTxt.Foreground = CardBord1.Background;

            SymbolTxt.FontSize = 100;

            SymbolTxt.Text = _mixedLettersList[_questionNumber].Transcription;
        }
    }
}
