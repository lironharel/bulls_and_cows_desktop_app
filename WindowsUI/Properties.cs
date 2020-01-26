using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUI
{
    static class Properties
    {
        public static List<Color> GetColorDictionary()
        {
            List<Color> colorDictionary = new List<Color>();
            colorDictionary.Add(Color.DarkMagenta);
            colorDictionary.Add(Color.Coral);
            colorDictionary.Add(Color.Chartreuse);
            colorDictionary.Add(Color.Aqua);
            colorDictionary.Add(Color.Blue);
            colorDictionary.Add(Color.Yellow);
            colorDictionary.Add(Color.DarkSlateBlue);
            colorDictionary.Add(Color.White);

            return colorDictionary;
        }
    }
}
