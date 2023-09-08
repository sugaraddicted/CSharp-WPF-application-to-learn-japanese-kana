using HiraganaApp.MVVM.ViewModel;
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
             var viewModel = new AlphabetViewModel();
            DataContext = viewModel;
        }
    }
}
