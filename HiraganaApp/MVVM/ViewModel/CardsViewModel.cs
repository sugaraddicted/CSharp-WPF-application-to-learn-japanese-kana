using HiraganaApp.Data;
using HiraganaApp.Help;
using HiraganaApp.MVVM.Model;
using HiraganaApp.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace HiraganaApp.MVVM.ViewModel
{
    public class CardsViewModel
    {
        public List<Letter> Letters = DataAccess.GetLetterList();

        public List<Letter> _mixedLettersList;

        public int _questionNumber;

        CardsPage _page;

        public RelayCommand MenuButtonCommand { get; private set; }
        public RelayCommand ExitButtonCommand { get; private set; }
        public RelayCommand NextButtonCommand { get; private set; }
        public RelayCommand ReverseButtonCommand { get; private set; }
        public RelayCommand PreviousButtonCommand { get; private set; }

        public CardsViewModel(CardsPage page)
        {
            _page = page;
            MenuButtonCommand = new RelayCommand(NavigateToMainPage);
            ExitButtonCommand = new RelayCommand(ExitApplication);
            NextButtonCommand = new RelayCommand(GoToNext);
            ReverseButtonCommand = new RelayCommand(ReverseCard);
            PreviousButtonCommand = new RelayCommand(GoToPrevious);
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

        public void Start()
        {
            _questionNumber = 0;
            _mixedLettersList = QuizHelper.MixLetters(Letters);
            SetSymbolSide();

            _page.LeftBorder1.Background = _page.Background;
            _page.LeftBorder2.Background = _page.Background;

            _page.NextTxt.Text = _mixedLettersList[_questionNumber + 1].Symbol;
        }

        public void GoToNext()
        {
            _questionNumber++;
            SetSymbolSide();

            SetPreviousCard();

            if (_questionNumber >= _mixedLettersList.Count - 1)
            {
                _questionNumber = 0;
            }

            _page.NextTxt.Text = _mixedLettersList[_questionNumber + 1].Symbol;
        }

        public void ReverseCard()
        {
            if (_page.SymbolTxt.Text == _mixedLettersList[_questionNumber].Transcription)
            {
                SetSymbolSide();
            }
            else
            {
                SetTranscriptionSide();
            }
        }


        public void GoToPrevious()
        {
            if (_questionNumber > 0)
            {
                _questionNumber--;

                SetSymbolSide();
                _page.NextTxt.Text = _mixedLettersList[_questionNumber + 1].Symbol;
            }
            else if (_questionNumber == 0)
            {
                SetSymbolSide();
                _page.NextTxt.Text = _mixedLettersList[_questionNumber + 1].Symbol;
            }
            SetPreviousCard();
        }

        public void SetPreviousCard()
        {
            if (_questionNumber > 0)
            {
                _page.LeftBorder1.Background = _page.RightBorder1.Background;
                _page.LeftBorder2.Background = _page.RightBorder2.Background;
                _page.PrevTxt.Foreground = _page.RightBorder1.Background;
                _page.PrevTxt.Text = _mixedLettersList[_questionNumber - 1].Symbol;
            }
            else
            {
                _page.LeftBorder1.Background = _page.Background;
                _page.LeftBorder2.Background = _page.Background;
                _page.PrevTxt.Foreground = _page.Background;

            }
        }

        public void SetSymbolSide()
        {
            _page.CardBord1.Background = _page.RightBorder1.Background;
            _page.CardBord2.Background = _page.RightBorder2.Background;
            _page.SymbolTxt.Foreground = _page.CardBord1.Background;

            _page.SymbolTxt.FontSize = 130;

            _page.SymbolTxt.Text = _mixedLettersList[_questionNumber].Symbol;
        }

        public void SetTranscriptionSide()
        {
            _page.CardBord1.Background = _page.RightBorder2.Background;
            _page.CardBord2.Background = _page.RightBorder1.Background;
            _page.SymbolTxt.Foreground = _page.CardBord1.Background;

            _page.SymbolTxt.FontSize = 100;

            _page.SymbolTxt.Text = _mixedLettersList[_questionNumber].Transcription;
        }
    }
}
