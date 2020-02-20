using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SharpML
{
    public class dataMiner
    {
        
        public static void ProcessDirectory(string networkshare)
        {
            List<string> extensions = new List<string> { "bat", "vbs", "cmd", "ps1", "sh", "pl", "txt", "xml", "cfg", "conf", "ini", "vba", "inf", "prf", "json", "cmp", "sql" };
            foreach (var file in Directory.EnumerateFiles(networkshare, "*.*", SearchOption.AllDirectories))
            {

                string ext = Path.GetExtension(file);
                if (extensions.Any(ext.Contains))
                    {
                    var fltext = File.ReadAllLines(file);
                    foreach (string fl in fltext)
                    {
                        using (System.IO.StreamWriter filered = new System.IO.StreamWriter(System.Environment.GetEnvironmentVariable("TEMP") + @"\model_data.txt", true))
                        {
                            filered.WriteLine(fl);
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }





}
