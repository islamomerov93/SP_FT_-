using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemProgramming_FinalTask_2.ViewModels;
using SystemProgramming_FinalTask_2.Views.UserControls;

namespace SystemProgramming_FinalTask_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM mainWindowVM;
        public MainWindow()
        {
            InitializeComponent();
            mainWindowVM = new MainWindowVM();
            mainWindowVM.Grid = MainGrid;
            mainWindowVM.Window = MW;
            mainWindowVM.ModeSelectionUCBtnClick.Execute(0);
            DataContext = mainWindowVM;
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            mainWindowVM.ModeSelectionUCBtnClick.Execute(0);
        }

        private void ExitBtnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += delegate { DragMove(); };
        }
    }
}
