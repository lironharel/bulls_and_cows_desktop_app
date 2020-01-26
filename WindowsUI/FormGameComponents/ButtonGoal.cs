using System.Drawing;
using System.Windows.Forms;

namespace WindowsUI.FormGameComponents
{
    class ButtonGoal : Button
    {
        public ButtonGoal(Point i_Location, int i_Size)
        {
            this.Location = i_Location;
            this.Size = new System.Drawing.Size(i_Size, i_Size);
            this.BackColor = System.Drawing.Color.Black;
            this.Enabled = false;
        }
    }
}
