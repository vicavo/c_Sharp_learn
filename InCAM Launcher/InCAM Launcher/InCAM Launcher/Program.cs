using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Com.FLS.Common;

namespace InCAM_Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // IncamJobList list = new IncamJobList(@"D:\InCAM\server\config\joblist.xml");
            // IncamDBlist list2 = new IncamDBlist(@"D:\InCAM\server\site_data\dblist.xml");
            // GenJobList listsd = new GenJobList(@"D:\Genesis\share\joblist");

            bool noInstance = true;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out noInstance))
            {
                if(!noInstance && 0 == args.Length)
                {
                    MessageBox.Show("Another instance of this application is running!\r\nFind it on the notify area or task manager.", "HELLO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Environment.Exit(1);
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    try
                    {
                        Application.Run(new MainForm(args));
                    }
                    catch(System.Exception ex)
                    {
                        MessageBox.Show("Sorry, we're in trouble now:\r\n" + ex.Message.ToString(), "Oooooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        /* We we get errors on comparing, exit anyway because we don't want to see any window */
                        if(0 != args.Length)
                        {
                            System.Environment.Exit(0);
                        }
                    }  
                }
            }
        }
    }
}
