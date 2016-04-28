using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminatorApp
{
    class AutoStartup
    {
        //constructor
        public AutoStartup(string fileName)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);



                registryKey.SetValue("TerminatorApp", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + fileName);
                
            }
            catch (Exception)
            {

                
            }

        }
    }
}
