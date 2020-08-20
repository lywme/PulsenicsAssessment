using System;
using System.Collections.Generic;
using System.Text;

namespace pulsenicsQ3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(multiply(5,6));
            Console.ReadLine();
        }

        //using recursion to do the multiplication, time complexity is O(N), N is the number of y
        public static int multiply(int x, int y)
        {
            if (y == 1)
            {
                return x;
            }
            else
            {
                return x + multiply(x, y - 1);
            }
        }
    }
}
