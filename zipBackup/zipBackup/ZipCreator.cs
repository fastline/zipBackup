using System.Diagnostics;

namespace ConsoleApplication1
{
    class ZipCreator
    {
        private string _zipBinPath;
        private string[] _srcPath;
        private string _dstPath;

        public ZipCreator(string _zipBinPath, string _dstPath, string[] _srcPath)
        {
            this._zipBinPath = _zipBinPath;
            this._dstPath = _dstPath;
            this._srcPath = _srcPath;
        }

        public string ZipBinPath
        {
            get
            {
                return _zipBinPath;
            }

            set
            {
                _zipBinPath = value;
            }
        }

        public string[] SrcPath
        {
            get
            {
                return _srcPath;
            }

            set
            {
                _srcPath = value;
            }
        }

        public string DstPath
        {
            get
            {
                return _dstPath;
            }

            set
            {
                _dstPath = value;
            }
        }

        public void createZip()
        {
            foreach (string currentSrc in this._srcPath)
            {
                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = this._zipBinPath;
                p.Arguments = "u -t7z \"" + this._dstPath + "\" \"" + currentSrc + "\" -mx=9";
                p.WindowStyle = ProcessWindowStyle.Normal;
                Process x = Process.Start(p);
                x.WaitForExit();
            }

        }
    }
}
