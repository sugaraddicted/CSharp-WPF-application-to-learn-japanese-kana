using HiraganaApp.MVVM.ViewModel;
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
            var viewModel = new MainViewModel();
            DataContext = viewModel;
        }
    }
}
