using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CSV_File.Csv
{
    // This anothe way to read CSV file
    /*** Here we used ( using CsvHelper; ) to read data  ***/
    public class CsvFile_CsvHelper
    {
        public void Read_Csv_File()
        {
            using (var streamReader = new StreamReader(@"C:\Users\samim\source\repos\JSON_XML_CSV_Files\CSV_File\Csv\Employee.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<Employee>().ToList();

                    foreach (var item in records)
                    {
                        Console.WriteLine($"{item.FirstName,-15} {item.LastName,-15} {item.Gender,-10} {item.Education,-20} {item.Phone,-20} {item.Email}");
                    }
                }
            }
        }

    }
}
