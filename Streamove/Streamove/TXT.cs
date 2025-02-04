using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamove
{
    public class TXT : ILog
    {
        private List<string> data = new List<string>();
        string filepath;

        public TXT(string filepath)
        {
            this.filepath = filepath;
        }

        public void Save(string message)
        {
            data.Add(message);
        }
        public void PrintLogger()
        {
            string[] lines = File.ReadAllLines(this.filepath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public void Write()
        {
            File.WriteAllLines(this.filepath, data);
        }
    }
}
