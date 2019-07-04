using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SystemProgramming_FinalTask_2.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ThirdModeUC.xaml
    /// </summary>
    public partial class ThirdModeUC : UserControl
    {
        ThirdModeVM ThirdModeVM;
        ObservableCollection<Process> processes;
        List<int> PIds;
        public ThirdModeUC(Window window)
        {
            InitializeComponent();
            ThirdModeVM = new ThirdModeVM();
            processes = ThirdModeVM.AllProcesses;
            PIds = ThirdModeVM.PIds;
            DataContext = ThirdModeVM;
            window.Height = UCW.Height + 36;
            window.Width = UCW.Width + 14;
            Task.Run(UpdateProcesses);
        }

        private void UpdateProcesses()
        {
            while (true)
            {
                foreach (var p in Process.GetProcesses())
                {
                    if (!PIds.Contains(p.Id) && !String.IsNullOrEmpty(p.MainWindowTitle))
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            processes.Add(p);
                            ThirdModeVM.AllProcesses = null;
                            ThirdModeVM.AllProcesses = processes;
                            PIds.Add(p.Id);
                            ThirdModeVM.PIds = null;
                            ThirdModeVM.PIds = PIds;
                        }));
                        
                    }
                }
            }
        }
    }
}
