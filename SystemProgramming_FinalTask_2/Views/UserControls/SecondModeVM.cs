using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SystemProgramming_FinalTask_2.Entities;
using SystemProgramming_FinalTask_2.Helper;
using SystemProgramming_FinalTask_2.ViewModels;

namespace SystemProgramming_FinalTask_2.Views.UserControls
{
    public partial class SecondModeUC : UserControl
    {
        SecondModeVM SecondModeVM;
        public SecondModeUC(Window window)
        {
            InitializeComponent();
            SecondModeVM = new SecondModeVM();
            DataContext = SecondModeVM;
            Priorities.ItemsSource = Enum.GetValues(typeof(ProcessPriorityClass)).Cast<ProcessPriorityClass>();
            Priorities.SelectedIndex = 0;
            window.Height = UCW.Height + 36;
            window.Width = UCW.Width + 14;
            Task.Run(UpdateProcesses);
        }

        private void LoadProcesses()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SecondModeVM.Processes.Add(new ProcessInfo(p));
                    }));
                }
            }
            foreach (var Process in SecondModeVM.Processes)
            {
                Report.WriteToReportFile(Process.ToString() + " was started at " + Process.Process.StartTime);
            }
        }

        private void UpdateProcesses()
        {
            while (true)
            {
                SecondModeVM.UpdateProcesses();
                Thread.Sleep(1000);
            }
        }

        private void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;

            if (listBox.SelectedItems.Count > 0)
            {
                SecondModeVM.SelectedProcess = ((ProcessInfo)listBox.SelectedItems[0]).Process;
            }
        }
        
        private void ChangePriority_OnClick(object sender, RoutedEventArgs e)
        {
            var priority = (ProcessPriorityClass)Priorities.SelectionBoxItem;
            SecondModeVM.SelectedProcess.PriorityClass = priority;
        }

        private void KillProcess_OnClick(object sender, RoutedEventArgs e)
        {
            SecondModeVM.SelectedProcess.Kill();
        }
    }
}
