using System;
using System.IO;
using System.Windows.Forms;

namespace StorefrontTraceUtility
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = @"C:\Program Files\Citrix\Receiver StoreFront\Admin\Trace";
            if (Directory.Exists(path))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Storefront not detected on this system!" + "\n" + "This application is intended for Citrix Storefront Servers." + "\n" + "This application will now exit.");
                Application.Exit();
            }            
        }
    }
}
