using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TerminatorApp
{
    class getExternalIP
    {
        //return the external IP as a string
        public static string getExIp()
        {
            string externalip = "";
            try
            {
                //string url = "http://checkip.dyndns.org";
                //System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                //System.Net.WebResponse resp = req.GetResponse();
                //System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                //string response = sr.ReadToEnd().Trim();
                //string[] a = response.Split(':');
                //string a2 = a[1].Substring(1);
                //string[] a3 = a2.Split('<');
                //string a4 = a3[0];

                //check the network connection
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    externalip = new WebClient().DownloadString("http://icanhazip.com").Trim();
                }
                else
                {
                    externalip = "No Network!";
                }
                

                return externalip;
            }
            catch (Exception)
            {
                return "Network connection error!";
            }
            
        }
    }
}
