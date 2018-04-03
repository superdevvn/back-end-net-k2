using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] DSSP;
            int n;
            Console.Write("Enter a Product:");
            n = int.Parse(Console.ReadLine());
            DSSP = new Product[n];
            Console.WriteLine("\n ***********Enter a Product************");
            for(int i = 0; i < n; i++)
            {
                DSSP[i] = new Product();
                Console.Write("Enter a Code {0}:", i + 1);
                DSSP[i].ProductCode = int.Parse(Console.ReadLine());
                Console.Write("Enter a Name:");
                DSSP[i].ProductName = Console.ReadLine();
                Console.Write("Enter a Price:");
                DSSP[i].ProductPrice = float.Parse(Console.ReadLine());
            }
            //show danh sach produc
            Console.WriteLine("\n*********List Product*********");
            foreach (Product pro in DSSP)
                pro.Show();
            Console.ReadLine();
        }
    }
}
