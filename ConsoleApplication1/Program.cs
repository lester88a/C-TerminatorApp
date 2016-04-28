using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static string externalip;

        static void Main(string[] args)
        {
            try
            {
                //first
                externalip = new WebClient().DownloadString("http://icanhazip.com");
                Console.WriteLine("The beginning IP: {0}", externalip);
                //detect IP changes
                NetworkChange.NetworkAddressChanged += new
                NetworkAddressChangedEventHandler(AddressChangedCallback);
                Console.WriteLine("Listening for address changes. Press any key to exit.");
                Console.ReadLine();
            }
            catch (Exception)
            {

                Console.WriteLine("NONO"); ;
            }
            Console.ReadLine();
        }
        //get local IP
        public static string GetPubIPAddress()
        {
            try
            {
                string currentIP = new WebClient().DownloadString("http://icanhazip.com");
                return currentIP;
            }
            catch (Exception)
            {

               return "NO"; 
            }
           
        }
        //listening IP changes
        static void AddressChangedCallback(object sender, EventArgs e)
        {

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in adapters)
            {
                string currentIPs = GetPubIPAddress();

                Console.WriteLine("The current IP: {0}", currentIPs);

                if (externalip != currentIPs)
                {
                    Console.WriteLine("Starting kill the application...");
                    //kill the process
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName("SummonerFactoryClient"))
                        {
                            if (proc.ProcessName.Contains("SummonerFactoryClient"))
                            {
                                proc.Kill();
                                Console.WriteLine("The application terminate successful!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Sorry, see this following errors:");
                        Console.WriteLine(ex); ;
                    }
                }
            }
        }
    }
}
