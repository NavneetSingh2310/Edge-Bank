using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ApteanEdgeBank_Final
{
   

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]
        static void Main(string[] args)
        {

         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
           
           
            Application.Exit();


        }
    }
}
