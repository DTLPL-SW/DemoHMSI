using System;
using System.Threading;
using System.Windows.Forms;

namespace DemoApplicationHMSI
{
    internal static class Program
    {
        static Mutex mutex = new Mutex(true, "{9F6F0ACD4-B9A1-45fd-A8CF-72F04E6BDE8T}");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //if (mutex.WaitOne(TimeSpan.Zero, true))
            //{
                Application.Run(new AdvicsLoginScreen());
                mutex.ReleaseMutex();
            //}
            //else
            //{
            //    MessageBox.Show("Application is already running");
            //}
        }
    }
}
