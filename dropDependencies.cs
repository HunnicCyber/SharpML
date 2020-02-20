using SharpML.Properties;
using System.IO;

namespace SharpML
{
    public class DropDependencies
    {
        public string DropModeltoDisk(string random_model_name)
        {
            string path_to_drop = Path.GetTempPath() + random_model_name + "mod.exe";
            File.WriteAllBytes(path_to_drop, Resources.model);
            return path_to_drop;
        }

        public string DropRulestoDisk(string random_model_name)
        {
            string path_to_drop = Path.GetTempPath() + random_model_name + "rul.bin";
            File.WriteAllBytes(path_to_drop, Resources.rules);
            return path_to_drop;
        }

        public string Drop10ktoDisk(string random_model_name)
        {
            string path_to_drop = Path.GetTempPath() + random_model_name + "tenk.txt";
            File.WriteAllText(path_to_drop, Resources._10k);
            return path_to_drop;
        }
    }
}
