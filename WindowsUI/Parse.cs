using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsUI.FormGameComponents;
using Logic;

namespace WindowsUI
{
    class Parse
    {
        internal static UserGuess UIGuessToLogicGuess(List<ButtonGuess> i_UIGuess, List<Color> i_ColorDictionary, GameManager i_GameManager)
        {
            List<eGuessOption> enumGuess = colorToEnum(i_UIGuess, i_ColorDictionary);
            UserGuess userGuess = new UserGuess(enumGuess, i_GameManager.GoalSequence);

            return userGuess;
        }

        private static List<eGuessOption> colorToEnum(List<ButtonGuess> i_ColorGuess, List<Color> i_ColorDictionary)
        {
            List<eGuessOption> enumGuess = new List<eGuessOption>();

            foreach(ButtonGuess colorGuess in i_ColorGuess)
            {
                eGuessOption eGuessElement = (eGuessOption)i_ColorDictionary.IndexOf(colorGuess.BackColor);
                enumGuess.Add(eGuessElement);
            }

            return enumGuess;
        }
    }
}
