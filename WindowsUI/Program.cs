using System.Windows.Forms;

namespace WindowsUI
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            new FormStartMenu().ShowDialog();
        }
    }
}
