using System.Text;

namespace zipBackup
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
            StringBuilder sb = new StringBuilder(500);
            sb.Append("u -t7z \"" + this._dstPath + "\" ");

            foreach (string currentSrc in this._srcPath)
            {
                sb.Append("\"").Append(currentSrc).Append("\" ");
            }

            ProcessHandler ph = new ProcessHandler(this._zipBinPath, sb.ToString(), "normal");
            ph.startProcess();
        }
    }
}
