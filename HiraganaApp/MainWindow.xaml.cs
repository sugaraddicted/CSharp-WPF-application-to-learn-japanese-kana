using HiraganaApp.MVVM.View;
using System.Windows;
using System.Windows.Input;

namespace HiraganaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Window;
        public MainWindow()
        {
            Window = this;  
            InitializeComponent();
            MainFrame.Content = new MainPage();
        }

        private void Move(object sender, RoutedEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Window.DragMove();
            }
        }
    }
}
