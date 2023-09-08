using HiraganaApp.Data;
using HiraganaApp.Help;
using HiraganaApp.MVVM.Model;
using HiraganaApp.MVVM.ViewModel;
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

        public CardsPage()
        {
            InitializeComponent();
            var viewModel = new CardsViewModel(this);
            DataContext = viewModel;
            viewModel.Start();
        }
    }
}
