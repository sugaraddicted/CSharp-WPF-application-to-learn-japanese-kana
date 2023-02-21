using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HiraganaApp.MVVM.View
{
    
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AlphabetButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AlphabetPage());
        }

        private void CardsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CardsPage());
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuizPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
