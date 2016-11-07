﻿using System;
using System.IO;
using System.Text;

namespace zipBackup
{
    static class PathValidator
    {
        /*public static bool isPathValid(string path)
        {
            if (Directory.Exists(path)) 
            {
                return true;
            }
            else
            {
                return File.Exists(path);
            }
        }*/

        public static void tryPath(string path)
        {
            if(!Directory.Exists(path) && !File.Exists(path))
            {
                throw new NotValidPathException("Path: " + path + " is not exists");
            }
        }

        public static bool isPathWritable(string path)
        {
            bool isWritable;
            StringBuilder sb = new StringBuilder(500);
            sb.Append(path).Append("test.txt");
            string testFile = sb.ToString();

            try
            {
                File.WriteAllText(testFile, testFile);
                File.Delete(testFile);
                isWritable = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Target is not writable!");
                isWritable = false;
            }
            
            return isWritable;
        }
    }
}
