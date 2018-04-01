using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            //UTF-8
            Console.OutputEncoding = Encoding.UTF8;
            //Array
            int[] arr = { 1, 9, 10, 59, 21, 26, 34, 25, 26, 27, 68 };
            //Print array
            Console.Write("Array: ");
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            //Count
            Console.WriteLine("\n\nCount\t\tSố phần tử của mảng: \t\t\t\t\t" + arr.Count());
            //Sum
            Console.WriteLine("\nSum\t\tTổng tất cả phần tử của mảng: \t\t\t\t" + arr.Sum());
            //Max
            Console.WriteLine("\nMax\t\tPhần tử lớn nhất của mảng: \t\t\t\t" + arr.Max());
            //Min
            Console.WriteLine("\nMin\t\tPhần tử nhỏ nhất của mảng: \t\t\t\t" + arr.Min());
            //Average
            Console.WriteLine("\nAverage\t\tTrung bình cộng của mảng: \t\t\t\t" + arr.Average());
            //Where
            Console.Write("\nWhere\t\tNhững phần tử lớn hơn 25: \t\t\t\t");
            arr.Where(val => val > 25).ToList().ForEach(val => Console.Write(val + " "));
            //All
            Console.WriteLine("\n\nAll\t\tCó phải mọi phần tử đều là số lẻ? \t\t\t" + arr.All(val => val % 2 == 0));
            //Any
            Console.WriteLine("\nAny\t\tCó phải có ít nhất một phần tử là số lẻ? \t\t" + arr.Any(val => val % 2 == 0));
            //Contains
            Console.WriteLine("\nContains\tMảng có bao gồm số 0 hay không? \t\t\t" + arr.Contains(0));
            //Distinct
            Console.Write("\nDistinct\tLoại bỏ giá trị giống nhau: \t\t\t\t");
            arr.Distinct().ToList().ForEach(val => Console.Write(val + " "));
            //First
            Console.WriteLine("\n\nFirst\t\tPhần tử đầu tiên lớn hơn 10, nếu không thì báo lỗi: \t" + arr.First(val => val > 10));
            //FirstOrDefault
            Console.WriteLine("\nFirstOrDefault\tPhần tử đầu tiên lớn hơn 100, nếu không thì gán null: \t" + arr.FirstOrDefault(val => val > 100));
        }
    }
}
