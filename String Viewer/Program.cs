using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace String_Viewer
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string text = Clipboard.GetText(TextDataFormat.Text);

                text = text.Replace("\\\'", "\'");
                text = text.Replace("\\\"", "\"");
                text = text.Replace("\\\\", "\\");
                text = text.Replace("\\0", "\0");
                text = text.Replace("\\a", "\a");
                text = text.Replace("\\f", "\f");
                text = text.Replace("\\n", "\n");
                text = text.Replace("\\r", "\r");
                text = text.Replace("\\t", "\t");
                text = text.Replace("\\v", "\v");


                Notepad.NotepadHelper.ShowText(text, "bruh");
            }
        }
    }
}
