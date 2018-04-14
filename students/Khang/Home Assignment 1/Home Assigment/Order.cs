using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Assigment
{
    public class Date
    {
        int day { get; set; } = 0;
        int month { get; set; } = 0;
        int year { get; set; } = 0;

        public Date(int Day, int Month, int Year)
        {
            day = Day; month = Month; year = Year;
        }
        public void showDate()
        {
            Console.WriteLine(day + "-" + month + "-" + year);
        }
        public string ToString()
        {
            return day + "-" + month + "-" + year;
        }
        public int CompareTo(Date anotherDate)
        {
            if (this.year > anotherDate.year)
                return 1;
            else if (this.year < anotherDate.year)
                return -1;
            else
            {
                if (this.month > anotherDate.month)
                    return 1;
                else if (this.month < anotherDate.month)
                    return -1;
                else
                {
                    if (this.day > anotherDate.day)
                        return 1;
                    else if (this.day < anotherDate.day)
                        return -1;
                    else return 0;
                }
            }
        }
    }


    public class Order
    {
        public string code { get; set; }// ma don hang
        public string productCode { get; set; } // ma san pham
        public int number { get; set; } // so luong
        public Date dayOrder { get; set; } // ngay dat hang

        public void showInfo()
        {
            Console.WriteLine("Code:" + code + " "
                + "Product code:" + productCode + " "
                + "Number: " + number + " "
                + "Day order: "+ dayOrder.ToString());
        }
    }
}
