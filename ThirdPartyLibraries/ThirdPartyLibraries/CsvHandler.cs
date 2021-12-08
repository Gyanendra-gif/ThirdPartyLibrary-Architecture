using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using System.Linq;

namespace ThirdPartyLibraries
{
    class CsvHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = @"E:\GitDemo\ThirdPartyLibraries\ThirdPartyLibraries\Files\address.csv"; // Initialization
            string exportFilePath = @"E:\GitDemo\ThirdPartyLibraries\ThirdPartyLibraries\Files\export.csv";

            using (var reader = new StreamReader(importFilePath)) // Readaing CSV File
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstName + "\t" + addressData.lastName + "\t" + 
                       addressData.address + "\t" + addressData.city + "\t" + addressData.state + "\t" + addressData.code );
                }

                using (var writer = new StreamWriter(exportFilePath)) // Writing CSV File
                using (var csvExport = new CsvWriter(writer, CultureInfo.CurrentCulture)) 
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
