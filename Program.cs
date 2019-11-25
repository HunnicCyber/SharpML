using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpML
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 11)
            {
                Console.WriteLine("\r\n\r\nSharpML: This tool will mine Active Directory, taking all text based files, line by line and " +
                    "copy them to the workstation. It will then create a list of AD users and write these to the workstation also. It will then drop the Machine Learning algorithm " +
                    "to the temp folder, and feed in the raw data and evaluate for password likelyhood where line exist with a username. If the check parameter is passed, these founds user/password combinations will " +
                    "be validated against a domain controller\r\n");
                Console.WriteLine("Usage:\r\n");
                Console.WriteLine("Standard Run:   SharpML.exe\r\n");
                Console.WriteLine("Check Run:    SharpML.exe check\r\n\r\n");
                Environment.Exit(1);
            }

        }


    }
}
