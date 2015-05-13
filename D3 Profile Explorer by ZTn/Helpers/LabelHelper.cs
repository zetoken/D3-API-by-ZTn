using System;
using System.Windows.Forms;

namespace ZTn.BNet.D3ProfileExplorer.Helpers
{
    class LabelHelper
    {
        public static void ConcatOnNewLine(ref Label source, string newLine)
        {
            source.Text += String.IsNullOrEmpty(source.Text) ? newLine : Environment.NewLine + newLine;
        }
    }
}
