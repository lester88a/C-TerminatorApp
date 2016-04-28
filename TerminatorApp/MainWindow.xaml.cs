using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TerminatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //external IP variable
        public static string exIP = getExternalIP.getExIp();
        public static string appName = "None";

        public MainWindow()
        {
            InitializeComponent();
        }

        //when the application is loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
            //assign the exIP to textbox
            textBoxLocalIP.Text = exIP;
            textBoxAppName.Text = "SummonerFactoryClient"; //set default application name
            textBoxStatus.Text = "Auto detected the external IP: " + exIP + "\n";

        }

        //start button
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            textBoxStatus.Text += "Application starts working...\n";
            //assign the exIP and appName from textBox
            //make sure user input a valid IP address 
            if (textBoxLocalIP.ToString().Length < 49 && textBoxLocalIP.ToString().Length>0)
            {
                exIP = textBoxLocalIP.Text;
                textBoxStatus.Text += "Assign the exIP.\nExIP:\t" + exIP + "\n";
                appName = textBoxAppName.Text;
                textBoxStatus.Text += "Assign the appName.\nApp Name:\t" + appName + "\n";

                //detect IP lively
                NetworkChange.NetworkAddressChanged += new
                NetworkAddressChangedEventHandler(AddressChangedCallback);
                textBoxStatus.Text += "Starts killing the application: [" + appName + "]\n";

            }
            else
            {
                textBoxStatus.Text += "ExIP is invalided" + "\n";
            }
            
        }
        //stop button
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        //listening IP changes
        static void AddressChangedCallback(object sender, EventArgs e)
        {

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in adapters)
            {
                string currentIPs = getExternalIP.getExIp();

                if (exIP != currentIPs)
                {
                    //kill the process
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName(appName))
                        {
                            if (proc.ProcessName.Contains(appName))
                            {
                                proc.Kill();
                                MessageBox.Show("The application: ["+appName+"] terminate successful!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sorry, see this following errors:\n"+ex);
                    }
                }
            }
        }

        private void lblHelp_Click(object sender, RoutedEventArgs e)
        {
            string msg = "Created By: Lester\nEmail:lester88a@gmail.com\n\n1.Open the application that needs to terminate and Connect VPN\n2.Type the VPN IP address or use default\n3.Type the app name or use default\n4.Click Start button\n5.Enjoy:)";
            MessageBox.Show(msg);
        }

        
    }
}
