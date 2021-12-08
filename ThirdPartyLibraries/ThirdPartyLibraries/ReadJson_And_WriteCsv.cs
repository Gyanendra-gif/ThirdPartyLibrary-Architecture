using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ThirdPartyLibraries
{
    class ReadJson_And_WriteCsv
    {
        public static void ImplementJSONInCSV()
        {
            string importFilePath = @"E:\GitDemo\ThirdPartyLibraries\ThirdPartyLibraries\Files\Export.json";
            string exportFilePath = @"E:\GitDemo\ThirdPartyLibraries\ThirdPartyLibraries\Files\JsonData.csv";

            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));

            using (var writer = new StreamWriter(exportFilePath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture)) 
            {
                csvExport.WriteRecords(addressData);
            }
        }
    }
}
