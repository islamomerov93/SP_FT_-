using System.Diagnostics;

namespace SystemProgramming_FinalTask_2.Entities
{
    public class ProcessInfo
    {
        public int Id => Process.Id;
        public string ProcessName => Process.ProcessName;
        public bool KeepAlive { get; set; }
        public Process Process { get; }
        public string FileName { get; }
        public string Arguments { get; }

        public ProcessInfo(Process process)
        {
            Process = process;
            FileName = process.StartInfo.FileName;
            Arguments = process.StartInfo.Arguments;
        }
    }
}
