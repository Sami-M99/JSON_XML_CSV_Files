using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XML_File
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Sortting_Salary_by_Selection_Sort();

            var xmlseri = new XmlSerializer(typeof(List<Employee>));
            var reader = new StreamReader(@"C:\Users\samim\source\repos\JSON_XML_CSV_Files\XML_File\XMLFile1.xml");
            var obj = (List<Employee>)xmlseri.Deserialize(reader);

            foreach (var item in obj)
            {
                Console.WriteLine($"{item.Id,-10} {item.FullName,-25} {item.Salary,-10} {item.Title}");
            }


        }

        static void Sortting_Salary_by_Selection_Sort()
        {
            var xmlseri = new XmlSerializer(typeof(List<Employee>));
            var reader = new StreamReader(@"C:\Users\samim\source\repos\JSON_XML_CSV_Files\XML_File\XMLFile1.xml");
            var obj = (List<Employee>)xmlseri.Deserialize(reader);


            for (int i = 0; i < obj.Count; i++)
            {
                int min = i;
                for (int j = i + 1; j < obj.Count; j++)
                {
                    if (obj[min].Salary.CompareTo(obj[j].Salary) > 0)
                        min = j;

                }
                if (min != i)
                {
                    var temp = obj[min];
                    obj[min] = obj[i];
                    obj[i] = temp;
                }
            }

            foreach (var item in obj)
            {
                Console.WriteLine($"{item.Id,-10} {item.FullName,-30} {item.Salary,-15} {item.Title}");
            }
        }


    }


    /**** Or we can write classes with out Attributes[...] ****/
    [XmlRoot(ElementName = "Employee")]
    public class Employee
    {

        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }

        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "Salary")]
        public double Salary { get; set; }

        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }
    }

    [XmlRoot(ElementName = "ArrayOfEmployee")]
    public class ArrayOfEmployee
    {
        [XmlElement(ElementName = "Employee")]
        public List<Employee> Employee { get; set; }
    }


}
