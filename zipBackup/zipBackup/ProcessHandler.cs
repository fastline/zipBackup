using System.Diagnostics;
using System.Text;

namespace zipBackup
{
    class ProcessHandler
    {
        private string _execPath;
        private string _arguments;
        private string _windowStyle;

        public ProcessHandler(string _execPath, string _arguments, string _windowStyle)
        {
            this._execPath = _execPath;
            this._arguments = _arguments;
            this._windowStyle = _windowStyle;
        }

        public void startProcess()
        {
            ProcessStartInfo psi = new ProcessStartInfo(this._execPath, this._arguments);

            if(this._windowStyle.Contains("normal"))
            {
                psi.WindowStyle = ProcessWindowStyle.Normal;
            }
            else
            {
                psi.WindowStyle = ProcessWindowStyle.Hidden;
            }
            Process p = Process.Start(psi);
            p.WaitForExit();
        }

    }
}
