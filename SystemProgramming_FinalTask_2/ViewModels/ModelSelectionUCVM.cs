using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SystemProgramming_FinalTask_2.Views.UserControls;

namespace SystemProgramming_FinalTask_2.ViewModels
{
    class ModeSelectionUCVM
    {
        public ModeSelectionUCVM(Grid grid,Window Window)
        {
            ModeSelectionUC modeSelectionUC = new ModeSelectionUC();
            Window.Height = modeSelectionUC.Height;
            Window.Width = modeSelectionUC.Width;
            grid.Children.Add(modeSelectionUC);
        }
        public ModeSelectionUCVM() { }
    }
}
