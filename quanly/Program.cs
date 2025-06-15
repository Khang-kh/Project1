using quanly.schedule;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly
{
    internal static class Program
    {
        public static string connectString = "Data Source = LAPTOP-KN62CACQ\\SQLEXPRESS;Initial Catalog=DB4;Integrated Security=True;";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new giaodienchinh());

        }
    }
}
