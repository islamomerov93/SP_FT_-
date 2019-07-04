using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProgramming_FinalTask_2.Commands.UCCommands;

namespace SystemProgramming_FinalTask_2.ViewModels
{
    public class ThirdModeVM : INotifyPropertyChanged
    {
        public ThirdModeVM()
        {
            AllProcesses = new ObservableCollection<Process>(Process.GetProcesses().Where(x=> !String.IsNullOrEmpty(x.MainWindowTitle)));
            PIds = new List<int>(Process.GetProcesses().Where(x => !String.IsNullOrEmpty(x.MainWindowTitle)).Select(x => x.Id));
        }
        private ObservableCollection<Process> allProcesses;
        public ObservableCollection<Process> AllProcesses
        {
            get { return allProcesses; }
            set { allProcesses = value; OnNotifyPropertyChanged(nameof(AllProcesses)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnNotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        private List<int> pIds;
        public List<int> PIds
        {
            get { return pIds; }
            set { pIds = value; }
        }

    }
}
