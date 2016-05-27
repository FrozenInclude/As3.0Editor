using System;
using System.Collections.Generic;
using System.Windows.Forms;
using As3._0Highlighter;
using System.Threading;
using System.IO;
namespace Tester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new 버그리포터());
                Application.Run(new Form1());
                Application.Run(new why());
                Application.Run(new As3Editor());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
               Application.Run(new 버그리포터());
            }
        }
    }
}