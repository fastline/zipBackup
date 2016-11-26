using System;
using System.IO;
using System.Text;

namespace zipBackup
{
    static class PathValidator
    {
        
        public static void tryPath(string path)
        {
            if(!Directory.Exists(path) && !File.Exists(path))
            {
                throw new NotValidPathException("Path: " + path + " is not exists");
            }
        }

        public static void checkPathWritable(string path)
        {
            PathValidator.tryPath(path);

            string testFile = path + "test.txt";

            try
            {
                File.WriteAllText(testFile, testFile);
                File.Delete(testFile);
            }
            catch
            {
                throw;
            }
        }
    }
}
