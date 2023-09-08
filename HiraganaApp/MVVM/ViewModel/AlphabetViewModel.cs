using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using HiraganaApp.MVVM.View;

namespace HiraganaApp.MVVM.ViewModel
{
    public class AlphabetViewModel
    {
        public RelayCommand MenuButtonCommand { get; private set; }
        public RelayCommand ExitButtonCommand { get; private set; }

        public AlphabetViewModel()
        {
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
    }
}
