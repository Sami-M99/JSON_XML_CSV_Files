using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_File.JSON_objects
{
    public class Json
    {
        string json = File.ReadAllText(@"C:\Users\samim\source\repos\JSON_XML_CSV_Files\JSON_File\JSON_objects\json1.json");
        Root obj;

        public Json()
        {
            obj = JsonConvert.DeserializeObject<Root>(json);
        }

        public void Print_object_data()
        {
            /* **** Simple print data **** */

            //// Reading all Texts from the file ==> using System.IO; 
            //string json = File.ReadAllText(@"C:\Users\samim\source\repos\JSON_XML_CSV_Files\JSON_File\JSON_objects\json1.json");
            //// Make Deserialize for an Object  ==> using Newtonsoft.Json;
            //var obj = JsonConvert.DeserializeObject<Root>(json);

            foreach (var item in obj.employee)
            {
                Console.WriteLine($"{item.id,-10} {item.fullName,-25} {item.salary,-10} {item.title}");
            }

        }

        public void Sortting_and_Searching_Salary_by_Merge_Sort()
        {
            /// Sortting Salary by Merge_Sort 

            Merge_Sort(obj.employee, 0, obj.employee.Count - 1);

            foreach (var item in obj.employee)
            {
                Console.WriteLine($"{item.id,-10} {item.fullName,-30} {item.salary,-15} {item.title}");
            }

            Console.WriteLine($"Salary of Employee [{Search(obj.employee, 20)}] = {obj.employee[Search(obj.employee, 20)].salary}");

            static void Merge_Sort(List<Employee> array, int first, int last)

            {
                if (first < last)
                {
                    int mid = first + (last - first) / 2;

                    // Divide
                    Merge_Sort(array, first, mid);
                    Merge_Sort(array, mid + 1, last);

                    // Conquer "Merge"
                    Merge(array, first, mid, last);

                }
            }

            static void Merge(List<Employee> array, int first, int mid, int last)
            {
                // Find sizes of two
                // subarrays to be merged
                int n1 = mid - first + 1;  // for First subArray is  array[firat ... mid]
                int n2 = last - mid;       // for Second subArray is array[mid+1 ... last]

                // Create temp arrays
                Employee[] Lift = new Employee[n1];
                Employee[] Right = new Employee[n2];
                int i, j;

                // Copy data to temp arrays
                for (i = 0; i < n1; ++i)
                    Lift[i] = array[first + i];
                for (j = 0; j < n2; ++j)
                    Right[j] = array[mid + 1 + j];

                // Merge the temp arrays

                // Initial indexes of first
                // and second subarrays
                i = 0;
                j = 0;

                // Initial index of merged
                // subarray array
                int k = first;
                while (i < n1 && j < n2)
                {
                    if (Lift[i].salary.CompareTo(Right[j].salary) < 0)
                    {
                        array[k] = Lift[i];
                        i++;
                    }
                    else
                    {
                        array[k] = Right[j];
                        j++;
                    }
                    k++;
                }

                // Copy remaining elements
                // of L[] if any
                while (i < n1)
                {
                    array[k] = Lift[i];
                    i++;
                    k++;
                }

                // Copy remaining elements
                // of R[] if any
                while (j < n2)
                {
                    array[k] = Right[j];
                    j++;
                    k++;
                }
            }

            static int Search(List<Employee> input, int key)
            {
                int first = 0;
                int last = input.Count - 1;

                while (true)
                {
                    if (first == last)
                        return (input[last].salary.Equals(key)) ? last : -1;

                    int middle = (first + last) / 2;

                    if (input[middle].salary.CompareTo(key) == 0)
                        return middle;
                    else if (input[middle].salary.CompareTo(key) < 0)
                        first = middle + 1;
                    else
                        last = middle;

                }
            }
        }

        public void Sortting_Salary_by_Selection_Sort()
        {

            for (int i = 0; i < obj.employee.Count; i++)
            {


                int min = i;
                for (int j = i + 1; j < obj.employee.Count; j++)
                {
                    if (obj.employee[min].salary.CompareTo(obj.employee[j].salary) > 0)
                        min = j;

                }
                if (min != i)
                {
                    var temp = obj.employee[min];
                    obj.employee[min] = obj.employee[i];
                    obj.employee[i] = temp;
                }
            }

            foreach (var item in obj.employee)
            {
                Console.WriteLine($"{item.id,-10} {item.fullName,-30} {item.salary,-15} {item.title}");
            }
        }

        public void Serialize_object_to_Json()
        {
            Sortting_Salary_by_Selection_Sort();
            Console.WriteLine("\n");

            // /* ** Take a c# object data and change it to jeson " Serialize "  ** */
            var CJson = JsonConvert.SerializeObject(obj);
            // print a Serialize json in a new sortting
            Console.WriteLine(CJson);

        }

        public void Heap_Sort()
        {
            heapSort(obj.employee, obj.employee.Count);

            static void heapSort(List<Employee> arr, int n)
            {
                for (int i = n / 2 - 1; i >= 0; i--)
                    heapify(arr, n, i);
                for (int i = n - 1; i >= 0; i--)
                {

                    var temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;
                    heapify(arr, i, 0);
                }
            }
            static void heapify(List<Employee> arr, int n, int i)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < n && arr[left].salary.CompareTo(arr[largest].salary) > 0)
                    largest = left;
                if (right < n && arr[right].salary.CompareTo(arr[largest].salary) > 0)
                    largest = right;
                if (largest != i)
                {
                    var swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;
                    heapify(arr, n, largest);
                }

            }

           
        }
        public void search(int index)
        {
            /**** Searching by LINQ ****/
            var item = obj.employee.Take(index).LastOrDefault();
            Console.WriteLine($"{item.id,-10} {item.fullName,-25} {item.salary,-10} {item.title}");

            /*** Try  ***/
            //DeleteMinMax(obj.employee);

            //static void DeleteMinMax(List<Employee> arr)
            //{
            //    if (arr is null)
            //        throw new IndexOutOfRangeException("There is no elemen to delete !!!");

            //    var temp = arr[0];
            //    arr[0] = arr[arr.Count - 1];
            //    //Array.SetValue(Array.GetValue(position - 1), 0);


            //    int index = 0;
            //    while (2 * index + 1 < arr.Count - 1)
            //    {
            //        var smallerIndex = 2 * index + 1;
            //        if (2 * index + 2 < arr.Count - 1 && arr[2 * index + 2].salary.CompareTo(arr[2 * index + 1].salary) < 0)
            //        {
            //            smallerIndex = 2 * index + 2;
            //        }

            //        if (arr[smallerIndex].salary.CompareTo(arr[index].salary) >= 0)
            //        {
            //            break;
            //        }

            //        var x = arr[smallerIndex];
            //        arr[smallerIndex] = arr[index];
            //        arr[index] = x;

            //        index = smallerIndex;

            //    }



            //}

        }

    }

    public class Employee
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public int salary { get; set; }
        public string title { get; set; }
    }

    public class Root
    {
        public List<Employee> employee { get; set; }
    }



}
