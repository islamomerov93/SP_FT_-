using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming_FinalTask_2.Helper
{
    public static class Report
    {
        public static void WriteToReportFile(string report)
        {
            using (StreamWriter sw = File.AppendText("Report.txt"))
            {
                sw.WriteLine(report);
            }
        }
    }
}
