using System.Drawing;
using System.Windows.Forms;

namespace WindowsUI.FormGameComponents
{
    class ButtonCheckGuess : Button
    {
        public ButtonCheckGuess(Point i_Location, int i_Width, int i_Height)
        {
            this.Location = i_Location;
            this.Size = new Size(i_Width, i_Height);
            this.Text = "-->";
            this.BackColor = SystemColors.Menu;
            this.FlatStyle = FlatStyle.System;
            this.Enabled = false;
        }
    }
}
