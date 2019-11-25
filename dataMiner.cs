using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SharpML
{
    class dataMiner
    {
        static double directorycount = 0;
        static double filecount = 0;
        static List<string> extensions = new List<string> { "bat", "vbs", "cmd", "ps1", "sh", "pl", "txt", "xml", "cfg", "conf", "ini", "vba", "inf", "prf", "json", "cmp" };
        private static void ProcessDirectory(List<string> directoryPaths, List<string> extensions)
        {

            foreach (var path in directoryPaths)
            {
                directorycount++;
                List<string> subdirs = new List<string>();
                try
                {

                    foreach (var e in Directory.GetDirectories(path))
                    {
                        subdirs.Add(e);
                    }
                }
                catch 
                {
                    
                }
                try
                {
                    var entries = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.TopDirectoryOnly);

                    foreach (var files in entries)
                    {
                        filecount++;
                        try
                        {

                            var fltext = File.ReadAllLines(files);
                            foreach (string fl in fltext)
                            {
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.Environment.GetEnvironmentVariable("TEMP") + @"\model_data.txt", true))
                                {
                                    file.WriteLine(fl);
                                }
                            }
                            
                            
                        }
                        catch
                        {
                        }
                    }
                }
                catch 
                {
                }
                if (subdirs.Count() > 0)
                    try
                    {
                        ProcessDirectory(subdirs, extensions);
                    }
                    catch
                    {
                    }
            }
        }
    }





}
