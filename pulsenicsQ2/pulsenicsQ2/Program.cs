using System;
using System.Collections.Generic;
using System.Text;

namespace pulsenicsQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(getAngles(7,15));
            Console.ReadLine();
        }

        public static double getAngles(int hour,int minute)
        {
            double hourAngle = 0;
            double minuteAngle = 0;
            hour = hour % 12;
            if ((hour >= 0 && hour <= 12) && (minute >= 0 && minute <= 60))
            {
                hourAngle = hour * 30 + minute*0.5;
                minuteAngle = minute * 6;

                return Math.Abs(hourAngle-minuteAngle);
            }
            else
            {
                //Console.WriteLine("Inputs time format is not valid!");
                return -1;
            }
        }
    }
}
