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

            StringBuilder sb = new StringBuilder(500);
            sb.Append(path).Append("test.txt");
            string testFile = sb.ToString();

            try
            {
                File.WriteAllText(testFile, testFile);
                File.Delete(testFile);
            }
            catch (Exception e)
            {
                throw new NotValidPathException("Path: " + path + " is not writable\n" + e);
            }
        }
    }
}
