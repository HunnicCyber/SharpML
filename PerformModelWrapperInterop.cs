using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpML
{
    class PerformModelWrapperInterop
    {
        public static string PerformDataPiping(string rules, string data, string users, string model, string msoftpass = "True", string tenk = "None")
        {
            ProcessStartInfo _processStartInfo = new ProcessStartInfo();
            _processStartInfo.FileName = model;
            _processStartInfo.Arguments = " " + data + " " + users + " " + rules + " " + msoftpass + " " + tenk;
            _processStartInfo.CreateNoWindow = true;
            _processStartInfo.UseShellExecute = false;
            _processStartInfo.RedirectStandardOutput = true;
            _processStartInfo.RedirectStandardError = true;
            Process myProcess = Process.Start(_processStartInfo);
            string error = myProcess.StandardError.ReadToEnd();
            string output = myProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(error);
            return output;
        }
    }
}
