using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SystemProgramming_FinalTask_2.Commands.UCCommands;
using SystemProgramming_FinalTask_2.Views.UserControls;

namespace SystemProgramming_FinalTask_2.ViewModels
{
    class ModeSelectionUCVM
    {
        MainWindowVM mainWindowVM;
        public ModeSelectionUCVM(MainWindowVM mainWindowVM)
        {
            this.mainWindowVM =mainWindowVM;
        }
    }
}
