using LINQtoCSV;
using System;
using System.Collections.Generic;

namespace CSV_File
{
    
    public class Program
    {
        static void Main(string[] args)
        {

            

        }

        /*** Here we used ( using LINQtoCSV; ) to read data  ***/
        static void Write_CSV_File()
        {
            var countryList = new List<Country>
            {
                new Country{ CountryName = "Yemen", Alpha2 = "YE", Alpha3 = "YEM", CountryCode = "0097", Region = "Asia"},
                new Country{ CountryName = "Afghanistan", Alpha2 = "AF", Alpha3 = "AFG", CountryCode = "4", Region = "Asia"},
                new Country{ CountryName = "Albania", Alpha2 = "AB", Alpha3 = "ALB", CountryCode = "6", Region = "Asia"}
            };


            var csvContext = new CsvContext();
            csvContext.Write(countryList, @"F:countryFile.csv");
            Console.WriteLine("CSV File Created");

            /***  OR Like this  ***/
            //var csvFileDescription = new CsvFileDescription
            //{
            //    FirstLineHasColumnNames = true,
            //    SeparatorChar = ','
            //};

            //var csvContext = new CsvContext();
            //csvContext.Write(countryList, @"F:\File\country010.csv", csvFileDescription);
            //Console.WriteLine("CSV File Created");
        }

        static void Read_CSV_File()
        {
            // To describe the contents of the file
            var csvFileDescription = new CsvFileDescription
            {
                // To say that the first line contains the names of the columns of the table
                FirstLineHasColumnNames = true,

                IgnoreUnknownColumns = true,

                // To select a Separator between a colums element
                SeparatorChar = ',',

                // If we want call a colum by a order index in table, we can make it : ture & and we must write [FieldIndex] in table class
                UseFieldIndexForReadingData = false
            };

            var csvContext = new CsvContext();

            var countries = csvContext.Read<Country>("country.csv");
            // // OR we can write it like this
            //var countries = csvContext.Read<Country>("country.csv", csvFileDescription);


            Console.WriteLine($"{"CountryName",-50} {"Alpha2",-10} {"Alpha3",-10} {"CountryCode",-10} {"Region"}");
            Console.WriteLine(new String('-', 100));
            foreach (var item in countries)
            {
                Console.WriteLine($"{item.CountryName,-50} {item.Alpha2,-10} {item.Alpha3,-10} {item.CountryCode,-10} {item.Region}");
            }

        }
    }

    [Serializable]
    public class Country
    {
        // [ CsvColumn ]
        // Name : to write a name of colum if properety dosen't a same naem
        // FieldIndex : if we don't now the name of property, we can use the order number of colum in table
        // OutputFormat : if we want select a format type of the variable
        [CsvColumn(Name = "name", FieldIndex = 1)]
        public string CountryName { get; set; }

        [CsvColumn(Name = "alpha-2", FieldIndex = 2)]
        public string Alpha2 { get; set; }

        [CsvColumn(Name = "alpha-3", FieldIndex = 3)]
        public string Alpha3 { get; set; }

        [CsvColumn(Name = "country-code", FieldIndex = 4)]
        public string CountryCode { get; set; }

        [CsvColumn(Name = "region", FieldIndex = 5)]
        public string Region { get; set; }
    }

}
