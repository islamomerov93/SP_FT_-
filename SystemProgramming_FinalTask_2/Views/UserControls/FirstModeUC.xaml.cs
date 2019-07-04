using System;
using System.Collections.Generic;
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

namespace SystemProgramming_FinalTask_2.Views.UserControls
{
    /// <summary>
    /// Interaction logic for FirstModeUC.xaml
    /// </summary>
    public partial class FirstModeUC : UserControl
    {
        FirstModeVM FirstModeVM;
        public FirstModeUC(Window window)
        {
            InitializeComponent();
            FirstModeVM = new FirstModeVM();
            DataContext = FirstModeVM;
            window.Height = UCW.Height + 36;
            window.Width = UCW.Width + 14;
        }
    }
}
