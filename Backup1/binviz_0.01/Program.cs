/*
 * This is BinVis: http://code.google.com/p/binvis/
 * It's licensed under GPL: http://www.gnu.org/copyleft/gpl.html
 * 
 * Contact: Marius Ciepluch, wishinet@gmail.com
 * 
 * Please open a ticket if you find a bug. Could help a lot! 
 */


using System;
using System.Windows.Forms;

namespace binviz_0._1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}