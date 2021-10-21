using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace TestApp.UI.Tools
{
    public class CSVParser : IDataParser
    {
        public IEnumerable<TResponse> Parse<TResponse>(string source)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IgnoreBlankLines = false,
            };

            using var reader = new StreamReader(source);
            using var csv = new CsvReader(reader, config);

            csv.Context.RegisterClassMap<EmpoloyeMap>();
            
            var records = new List<TResponse>();
            var isHeader = true;

            while (csv.Read())
            {
                if (isHeader)
                {
                    csv.ReadHeader();
                    isHeader = false;
                    continue;
                }

                records.Add(csv.GetRecord<TResponse>());
            }

            return records;
        }
    }
}
