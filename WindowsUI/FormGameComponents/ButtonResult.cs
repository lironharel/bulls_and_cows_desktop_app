using System.Drawing;
using System.Windows.Forms;

namespace WindowsUI.FormGameComponents
{
    class ButtonResult : Button
    { 
        public ButtonResult(Point i_Location, int i_Size)
        {
            this.Location = i_Location;
            this.Size = new Size(i_Size, i_Size);
            this.BackColor = SystemColors.Menu;
            this.FlatAppearance.BorderColor = Color.Silver;
            this.Enabled = false;
        }
    }
}
