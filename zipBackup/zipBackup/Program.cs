using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApplication1
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
                ProcessStartInfo psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            }
        }
    }
}
