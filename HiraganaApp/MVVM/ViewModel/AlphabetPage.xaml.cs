using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace HiraganaApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for AlphabetPage.xaml
    /// </summary>
    public partial class AlphabetPage : Page
    {
        public AlphabetPage()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
