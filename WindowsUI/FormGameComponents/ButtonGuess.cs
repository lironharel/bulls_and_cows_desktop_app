using System.Drawing;
using System.Windows.Forms;

namespace WindowsUI.FormGameComponents
{
    class ButtonGuess : Button
    {
        public ButtonGuess(Point i_Location, int i_Size)
        {
            this.Location = i_Location;
            this.Size = new Size(i_Size, i_Size);
            this.BackColor = SystemColors.Menu;
            this.Enabled = false;
        }
    }
}
