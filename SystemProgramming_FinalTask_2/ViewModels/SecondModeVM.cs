using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using SystemProgramming_FinalTask_2.Entities;

namespace SystemProgramming_FinalTask_2.ViewModels
{
    public class SecondModeVM : INotifyPropertyChanged
    {
        public SecondModeVM()  { }

        private Process selectedProcess;
        public Process SelectedProcess
        {
            get => selectedProcess;
            set { selectedProcess = value; OnPropertyChanged("SelectedProcess"); }
        }

        public ObservableCollection<ProcessInfo> Processes { get; } = new ObservableCollection<ProcessInfo>();

        public void UpdateProcesses()
        {
            var currentIds = Processes.Select(p => p.Id).ToList();

            foreach (var p in Process.GetProcesses())
            {
                if (!currentIds.Remove(p.Id) && !String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Processes.Add(new ProcessInfo(p));
                    }));
                }
            }

            foreach (var id in currentIds)
            {
                var process = Processes.First(p => p.Id == id);
                if (process.KeepAlive)
                {
                    Process.Start(process.ProcessName, process.Arguments);
                }
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Processes.Remove(process);
                }));
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
