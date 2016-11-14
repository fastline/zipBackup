using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using System;

namespace zipBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.createLogSource();
            Logger.writeEventLog("CICA", "zipBackup");
            string confPath = "settings.json";

            try
            {
                PathValidator.tryPath(confPath);
                Config dConfig = JsonConvert.DeserializeObject<Config>(File.ReadAllText(confPath));
                dConfig.checkPaths();
                Console.Write(dConfig.ToString());
                ZipCreator zc = new ZipCreator(dConfig.ZipBinPath, dConfig.DstPath, dConfig.SrcPath, dConfig.ZipProgressVisible);
                zc.createZip();
                
                if (dConfig.ShutdownAfter)
                {
                    ProcessHandler ph = new ProcessHandler("shutdown", "-r -t 00", "false");
                    ph.startProcess();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nJobs done");
            Console.ReadKey();
        }
    }
}
