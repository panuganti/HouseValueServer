using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseHousingData
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void ParseHousingData(string inputDir, string outputDir)
        {
            var files = Directory.GetFiles(inputDir);
            foreach(var file in files)
            {
                var housingJson = File.ReadAllText(file);
                var housing = JsonConvert.DeserializeObject<Housing>(housingJson);
                File.WriteAllText(Path.Combine(outputDir, Path.GetFileName(file)), JsonConvert.SerializeObject(housing));
            }
        }
    }
}
