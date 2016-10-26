using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace zipBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            string confPath = "settings.json";
            string json = File.ReadAllText(confPath);

            Config dConfig = JsonConvert.DeserializeObject<Config>(json);
            dConfig.setDstPath();

            ZipCreator zc = new ZipCreator(dConfig.ZipBinPath, dConfig.DstPath, dConfig.SrcPath);
            zc.createZip();

            if (dConfig.ShutdownAfter)
            {
                ProcessHandler ph = new ProcessHandler("shutdown", "-r -t 00", "false");
                ph.startProcess();
            }
        }
    }
}
