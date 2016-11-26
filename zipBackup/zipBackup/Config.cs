using System;
using System.Text;
using System.Collections.Generic;

namespace zipBackup
{
    public class Config
    {
        private List<string> _srcPath;
        private string _dstPath;
        private bool _shutdownAfter;
        private string _zipBinPath;
        private string _zipProgressVisible;
        
        public Config()
        {
            this._srcPath = new List<string>();
            this._dstPath = "";
            this._shutdownAfter = false;
            this.ZipProgressVisible = "normal";
        }

        public void checkPaths()
        {
            try
            {
                foreach (string item in this._srcPath)
                {
                    PathValidator.tryPath(item);
                }
                PathValidator.tryPath(this._dstPath);
                PathValidator.tryPath(this._zipBinPath);
            }
            catch
            {
                throw;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append("Shutdown After: ").AppendLine(this._shutdownAfter.ToString());
            sb.Append("Destination: ").AppendLine(this._dstPath);
            sb.Append("7zip exe: ").AppendLine(this._zipBinPath);
            sb.AppendLine("Source Dirs");
            foreach (string item in this._srcPath)
            {
                sb.Append("     Index ").Append(" Path: ").AppendLine(item);
            }

            return sb.ToString();
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
                try
                {
                    PathValidator.checkPathWritable(value);
                    string _compName = System.Environment.MachineName;
                    string _usrName = System.Environment.UserName;
                    StringBuilder sb = new StringBuilder(500);
                    _dstPath = sb.Append(value).Append(@"\").Append(_compName).Append(@"-").Append(_usrName).Append(@".7z").ToString();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<string> SrcPath
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
                PathValidator.tryPath(value);
                _zipBinPath = value;
            }
        }

        public string ZipProgressVisible
        {
            get
            {
                return _zipProgressVisible;
            }

            set
            {
                _zipProgressVisible = value;
            }
        }
    }
}
