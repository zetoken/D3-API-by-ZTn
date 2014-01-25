using System;
using System.Windows.Forms;

namespace ZTn.BNet.D3ProfileExplorer
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GuiD3ProfileExplorer());
        }
    }
}
