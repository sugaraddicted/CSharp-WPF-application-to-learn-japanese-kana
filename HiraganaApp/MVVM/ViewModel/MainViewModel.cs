using HiraganaApp.MVVM.View;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;

namespace HiraganaApp.MVVM.ViewModel
{
    public class MainViewModel
    {
        public RelayCommand AlphabetButtonCommand { get; private set; }
        public RelayCommand CardsButtonCommand { get; private set; }
        public RelayCommand QuizButtonCommand { get; private set; }
        public RelayCommand ExitButtonCommand { get; private set; }

        public MainViewModel()
        {
            AlphabetButtonCommand = new RelayCommand(NavigateToAlphabetPage);
            CardsButtonCommand = new RelayCommand(NavigateToCardsPage);
            QuizButtonCommand = new RelayCommand(NavigateToQuizPage);
            ExitButtonCommand = new RelayCommand(ExitApplication);
        }

        private void NavigateToAlphabetPage()
        {
            if (Application.Current.MainWindow.FindName("MainFrame") is Frame frame)
            {
                frame.Navigate(new AlphabetPage());
            }
        }

        private void NavigateToCardsPage()
        {
            if (Application.Current.MainWindow.FindName("MainFrame") is Frame frame)
            {
                frame.Navigate(new CardsPage());
            }
        }

        private void NavigateToQuizPage()
        {
            if (Application.Current.MainWindow.FindName("MainFrame") is Frame frame)
            {
                frame.Navigate(new QuizPage());
            }
        }
        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
