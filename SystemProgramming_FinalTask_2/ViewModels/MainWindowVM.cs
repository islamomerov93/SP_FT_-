﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SystemProgramming_FinalTask_2.Views.UserControls;

namespace SystemProgramming_FinalTask_2.ViewModels
{
    class MainWindowVM
    {
        ModeSelectionUCVM ModeSelectionUCVM;

        public MainWindowVM(Grid grid, Window Window)
        {
            ModeSelectionUCVM = new ModeSelectionUCVM(grid,Window);
        }
    }
}