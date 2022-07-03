using JSON_File.Collections_JSON_objects;
using JSON_File.JSON_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace JSON_File
{
    public class Program
    {
        /* This wibsite change Json file to c# classes */
        /**** https://json2csharp.com/ *****/

        static void Main(string[] args)
        {

            //var p = new Collections_Json();
            //p.Print_object_data();


            var o = new Json();
            //// o.Sortting_Salary_by_Selection_Sort();
            //// o.Sortting_and_Searching_Salary_by_Merge_Sort();
            // o.Heap_Sort();


            o.search(872);

            //o.Print_object_data();


        }

        

    }


   

}
