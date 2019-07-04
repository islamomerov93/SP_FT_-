using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SystemProgramming_FinalTask_2.ViewModels;
using SystemProgramming_FinalTask_2.Views.UserControls;

namespace SystemProgramming_FinalTask_2.Commands.UCCommands
{
    public class UCBtnClick : ICommand
    {
        MainWindowVM MainWindowVM;
        public UCBtnClick(MainWindowVM MainWindowVM)
        {
            this.MainWindowVM = MainWindowVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int i = Convert.ToInt32(parameter);
            MainWindowVM.Grid.Children.Clear();
            if (i == 0) MainWindowVM.Grid.Children.Add(new ModeSelectionUC(MainWindowVM));
            else if (i == 1) MainWindowVM.Grid.Children.Add(new FirstModeUC(MainWindowVM.Window));
            else if (i == 2) MainWindowVM.Grid.Children.Add(new SecondModeUC(MainWindowVM.Window));
            else MainWindowVM.Grid.Children.Add(new ThirdModeUC(MainWindowVM.Window));
        }
    }
}
