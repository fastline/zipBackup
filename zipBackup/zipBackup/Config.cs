using System.Text;

namespace zipBackup
{
    public class Config
    {
        private string[] _srcPath;
        private string _dstPath;
        private bool _shutdownAfter;
        private string _zipBinPath;

        public Config()
        {
            this._srcPath = new string[0];
            this._dstPath = "";
            this._shutdownAfter = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append("Shutdown After: ").AppendLine(this._shutdownAfter.ToString());
            sb.Append("Destination: ").AppendLine(this._dstPath);
            sb.Append("7zip exe: ").AppendLine(this._zipBinPath);
            sb.AppendLine("Source Dirs");
            for (int i = 0; i < this._srcPath.Length; i++)
            {
                sb.Append("     Index ").Append(i).Append(" Path: ").AppendLine(this._srcPath[i]);
            }
            return sb.ToString();
        }

        public void setDstPath()
        {
            string _compName = System.Environment.MachineName;
            string _usrName = System.Environment.UserName;
            StringBuilder sb = new StringBuilder(500);
            this._dstPath = sb.Append(this._dstPath).Append(@"\").Append(_compName).Append(@"-").Append(_usrName).Append(@".7z").ToString();
        }

        public bool ShutdownAfter
        {
            get
            {
                return _shutdownAfter;
            }

            set
            {
                _shutdownAfter = value;
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
    }
}
