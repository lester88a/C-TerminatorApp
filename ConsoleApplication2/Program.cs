using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            //{
            //    Console.WriteLine("Good");
            //}
            //else
            //{
            //    Console.WriteLine("Bad");
            //}

            string fileFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            string fileLocation = System.AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine(fileFullPath.Remove(0, fileLocation.Length));

        }
    }
}
