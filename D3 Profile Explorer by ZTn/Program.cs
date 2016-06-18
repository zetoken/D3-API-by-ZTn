using System;
using System.Windows.Forms;
using ZTn.BNet.D3ProfileExplorer.ExplorerLight;

namespace ZTn.BNet.D3ProfileExplorer
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new D3ProfileExplorerLight());
        }
    }
}
