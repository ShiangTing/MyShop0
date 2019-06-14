using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)

        {
            int d = 1;
            string str = Convert.ToString(d, 2);
            str = str.PadLeft(10, '0');    //補足四碼

            Console.WriteLine("{0}",str);

            Console.ReadLine();
        }
    }
}
