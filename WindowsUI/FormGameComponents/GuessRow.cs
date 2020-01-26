using System.Collections.Generic;
using System.Drawing;

namespace WindowsUI.FormGameComponents
{
    class GuessRow
    {
        private readonly List<ButtonGuess> r_GuessButtons;
        public List<ButtonGuess> GuessButtons
        {
            get { return r_GuessButtons; }
        }
        private readonly ButtonCheckGuess r_CheckButton;
        public ButtonCheckGuess CheckButton
        {
            get { return r_CheckButton;}
        }
        private readonly List<ButtonResult> r_ResultButtons;
        public List<ButtonResult> ResultButtons
        {
            get { return r_ResultButtons; }
        }
        private int m_RemainingGuesses;
        public int RemainingGuesses
        {
            get { return m_RemainingGuesses;}
        }

        public GuessRow(
            List<ButtonGuess> i_GuessButtons,
            ButtonCheckGuess i_CheckButton,
            List<ButtonResult> i_ResultButtons,
            int i_SequenceLength)
        {
            this.r_GuessButtons = i_GuessButtons;
            this.r_CheckButton = i_CheckButton;
            this.r_ResultButtons = i_ResultButtons;
            this.m_RemainingGuesses = i_SequenceLength;
        }

        public void DecrementRemainingSelections()
        {
            m_RemainingGuesses--;
            if(m_RemainingGuesses == 0)
            {
                r_CheckButton.Enabled = true;
            }
        }

        public void EnableGuessButtons()
        {
            foreach(ButtonGuess guessButton in r_GuessButtons)
            {
                guessButton.Enabled = true;
            }
        }

        public void DisableButtons()
        {
            foreach (ButtonGuess guessButton in r_GuessButtons)
            {
                guessButton.Enabled = false;
            }

            r_CheckButton.Enabled = false;
        }

        public void SetResultColors(int i_Bulls, int i_Cows)
        {
            for(int i = 0; i < i_Bulls + i_Cows; i++)
            {
                if(i < i_Bulls)
                {
                    r_ResultButtons[i].BackColor = Color.Black;
                }

                else
                {
                    r_ResultButtons[i].BackColor = Color.Yellow;
                }
            }
        }
    }
}
