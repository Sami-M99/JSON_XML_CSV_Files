using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_File.Collections_JSON_objects
{
    public class Collections_Json
    {

        public void Print_object_data()
        {

            /*  for  Json2 file */
            // Reading all Texts from the file ==> using System.IO; 
            string json2 = File.ReadAllText(@"C:\Users\samim\source\repos\JSON_XML_CSV_Files\JSON_File\Collections_JSON_objects\Collections_json.json");
            // Make Deserialize for an Object but here Collections[] ====  <Class_Name[]>
            var obj2 = JsonConvert.DeserializeObject<Root[]>(json2);

            foreach (var i in obj2)
            {
                foreach (var item in i.teacher)
                {
                    Console.WriteLine($"{item.id,-10} {item.fullName,-25} {item.salary,-10} {item.title}");
                }

                Console.WriteLine("\n");

                foreach (var item in i.Student)
                {
                    Console.WriteLine($"{item.Id,-10} {item.Name,-15} {item.Class}");
                }
            }

        }
    }


    public class Root
    {
        public List<Teacher> teacher { get; set; }
        public List<Student> Student { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
    }

    public class Teacher
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public int salary { get; set; }
        public string title { get; set; }
    }

}
