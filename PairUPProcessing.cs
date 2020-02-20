using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Text.RegularExpressions;

namespace SharpML
{
    public class PairUPProcessing
    {
        public static void RunAuthCheck(string data_to_process)
        {
            try
            {

                Console.WriteLine("  ---------- 7. Authentication Test Results ----------   \r\n");

                bool is_pass = false;
                var result = Regex.Split(data_to_process, "\r\n|\r|\n");
                foreach (string line in result)
                {
                    var single_user = line.Split();

                    string user = single_user[0];
                    string pass = single_user[2];
                    string domain = System.Environment.UserDomainName;


                    Console.WriteLine("Trying user: " + user + " with Password: " + pass + "\r\n");

                    is_pass = ADAuth.Authenticate(user, pass, domain);

                    if (is_pass == true)
                    {
                        Console.WriteLine("SharpML has succesfully identified user: " + user + " with password: " + pass + " as valid\r\n");
                    }
                    else
                    {
                        Console.WriteLine("The user: " + user + " with password: " + pass + " is invalid\r\n");
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                // handle error here
            }


        }
    }
}
