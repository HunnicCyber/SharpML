using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;

namespace SharpML
{
    public class ADObjects
    {
        public static List<string> ADuser()
        {
            DirectoryEntry directoryEntry = new DirectoryEntry("WinNT://" + Domain.GetComputerDomain());
            List<string> userNames = new List<string>();

            foreach (DirectoryEntry child in directoryEntry.Children)
            {
                if (child.SchemaClassName == "User")
                {
                    userNames.Add(child.Name);
                }

            }
            return userNames;
        }

        
    }
}