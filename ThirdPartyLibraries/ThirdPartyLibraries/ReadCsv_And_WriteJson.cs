using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdPartyLibraries
{
    class ReadCsv_And_WriteJson
    {
        public static void ImplementCSVInJSON() 
        {
            string importFilePath = @"E:\GitDemo\ThirdPartyLibraries\ThirdPartyLibraries\Files\address.csv";
            string exportFilePath = @"E:\GitDemo\ThirdPartyLibraries\ThirdPartyLibraries\Files\Export.json";

            using (var reader = new StreamReader(importFilePath)) // Readaing CSV File
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture)) 
            {
                var records = csv.GetRecords<AddressData>().ToList();
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstName + "\t" + addressData.lastName + "\t" +
                       addressData.address + "\t" + addressData.city + "\t" + addressData.state + "\t" + addressData.code);
                }
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath)) // Writing Json File
                using (JsonWriter writer = new JsonTextWriter(sw)) 
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}