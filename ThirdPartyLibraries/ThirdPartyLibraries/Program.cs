using System;

namespace ThirdPartyLibraries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Third Party Libraries");
            CsvHandler.ImplementCSVDataHandling();
            ReadCsv_And_WriteJson.ImplementCSVInJSON();
            ReadJson_And_WriteCsv.ImplementJSONInCSV();
        }
    }
}
