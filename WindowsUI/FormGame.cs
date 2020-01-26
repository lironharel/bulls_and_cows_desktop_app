using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsUI.FormGameComponents;
using Logic;

namespace WindowsUI
{
    class FormGame : Form
    {
        private readonly List<ButtonGoal> r_GoalRow;
        private readonly List<GuessRow> r_GuessRows;
        private readonly GameManager r_GameManager;
        private readonly FormColorPick r_ColorForm;
        public readonly List<Color> r_ColorDictionary;
        private const int k_SequenceLength = 4;
        private const int k_MarginTop = 15;
        private const int k_MarginBottom = 5;
        private const int k_MarginLeft = 15;
        private const int k_MarginRight = 5;
        private const int k_GoalButtonSize = 50;
        private const int k_GoalButtonsGap = 5;
        private const int k_GoalToGuessGap = 25;
        private const int k_GuessMarginFromTop = k_MarginTop + k_GoalButtonSize + k_GoalToGuessGap;
        private const int k_GuessButtonSize = 50;
        private const int k_GuessButtonsGap = 5;
        private const int k_CheckButtonHeight = 20;
        private const int k_CheckButtonWidth = 40;
        private const int k_CheckToResultGap = 12;
        private const int k_ResultButtonSize = 18;
        private const int k_ResultButtonsGap = 1;
        private const int k_ResultButtonRows = 2;

        public FormGame(int i_NumberOfGuesses)
        {
            this.r_GoalRow = new List<ButtonGoal>();
            this.r_GuessRows = new List<GuessRow>();
            this.r_GameManager = new GameManager(i_NumberOfGuesses);
            this.r_ColorForm = new FormColorPick();
            this.r_ColorDictionary = Properties.GetColorDictionary();
            initializeComponent(i_NumberOfGuesses);
        }
        private void initializeComponent(int i_NumberOfGuesses)
        {
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.Text = "Bulls and Cows";
            this.BackColor = SystemColors.Info;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            initFormSize(i_NumberOfGuesses);
            initGoalRow();
            initGuessRows(i_NumberOfGuesses);
        }
        private void initFormSize(int i_NumberOfGuesses)
        {
            int formHeight = k_GuessMarginFromTop
                             + (k_GuessButtonSize + k_GuessButtonsGap) * i_NumberOfGuesses
                             + k_MarginBottom;
            int formWidth = k_MarginLeft
                            + (k_GuessButtonSize + k_GuessButtonsGap) * k_SequenceLength
                            + k_CheckButtonWidth + k_CheckToResultGap
                            + (k_ResultButtonSize + k_ResultButtonsGap) * 2
                            + k_MarginRight;

            this.ClientSize = new Size(formWidth, formHeight);
        }
        private void initGoalRow()
        {
            for(int i = 0; i < k_SequenceLength; i++)
            {
                Point buttonLoc = new Point(
                    k_MarginLeft + ((k_GoalButtonSize + k_GoalButtonsGap) * i), 
                    k_MarginTop);
                ButtonGoal goalButton = new ButtonGoal(buttonLoc, k_GoalButtonSize);

                r_GoalRow.Add(goalButton);
                this.Controls.Add(goalButton);
            }
        }
        private void initGuessRows(int i_NumberOfGuesses)
        {
            for(int rowNumber = 0; rowNumber < i_NumberOfGuesses; rowNumber++)
            {
                List<ButtonGuess> guessButtons = initGuessButtons(rowNumber);
                ButtonCheckGuess checkButton = initCheckButton(rowNumber);
                List<ButtonResult> resultButtons = initResultButtons(rowNumber);

                r_GuessRows.Add(new GuessRow(guessButtons, checkButton, resultButtons, k_SequenceLength));
            }

            r_GuessRows[0].GuessButtons[0].Select();
        }
        private List<ButtonGuess> initGuessButtons(int i_rowNumber)
        {
            List<ButtonGuess> guessButtons = new List<ButtonGuess>();

            for(int i = 0; i < k_SequenceLength; i++)
            {
                Point buttonLoc = new Point(
                    k_MarginLeft + ((k_GuessButtonSize + k_GoalButtonsGap) * i),
                    k_GuessMarginFromTop + ((k_GuessButtonsGap + k_GuessButtonSize) * i_rowNumber));

                ButtonGuess guessButton = new ButtonGuess(buttonLoc, k_GuessButtonSize);
                guessButton.Click += guessButton_Click;
                guessButtons.Add(guessButton);
                this.Controls.Add(guessButton);
            }

            return guessButtons;
        }
        private ButtonCheckGuess initCheckButton(int i_RowNumber)
        {
            const int k_MarginFromRowTop = (k_GuessButtonSize - k_CheckButtonHeight) / 2;
            Point buttonLoc = new Point(
                k_MarginLeft
                + (k_SequenceLength * (k_GuessButtonSize + k_GuessButtonsGap)),
                k_GuessMarginFromTop
                + (i_RowNumber * (k_GuessButtonSize + k_GuessButtonsGap))
                + k_MarginFromRowTop);
            ButtonCheckGuess checkButton = new ButtonCheckGuess(buttonLoc, k_CheckButtonWidth, k_CheckButtonHeight);

            checkButton.Click += checkButton_Click;
            this.Controls.Add(checkButton);

            return checkButton;
        }
        private List<ButtonResult> initResultButtons(int i_RowNumber)
        {
            List<ButtonResult> resultButtons = new List<ButtonResult>();
            int k_ButtonsPerRow = k_SequenceLength / k_ResultButtonRows;

            for(int i = 0; i < k_ResultButtonRows; i++)
            {
                for(int j = 0; j < k_ButtonsPerRow; j++)
                {
                    Point buttonLocation = getResultButtonLocation(i, j, i_RowNumber);
                    ButtonResult resultButton = new ButtonResult(buttonLocation, k_ResultButtonSize);
                    this.Controls.Add(resultButton);
                    resultButtons.Add(resultButton);
                }
            }

            return resultButtons;
        }
        private static Point getResultButtonLocation(int i_ResultRow, int i_ResultColumn, int i_RowNumber)
        {
            const int k_MarginFromRowTop = (k_GuessButtonSize - k_ResultButtonSize * k_ResultButtonRows
                                                            - k_ResultButtonsGap * (k_ResultButtonRows - 1)) / 2;
            int xPosition = k_MarginLeft + (k_GuessButtonSize + k_GuessButtonsGap) * k_SequenceLength
                                         + k_CheckButtonWidth + k_CheckToResultGap
                                         + (k_ResultButtonSize + k_ResultButtonsGap) * i_ResultColumn;
            int yPosition = k_GuessMarginFromTop + (k_GuessButtonSize + k_GuessButtonsGap) * i_RowNumber
                                                 + k_MarginFromRowTop + (k_ResultButtonSize + k_ResultButtonsGap)
                                                 * i_ResultRow;

            return new Point(xPosition, yPosition);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            runGame();
        }
        private void runGame()
        {
            updateColorFormGuessRow();
            r_GuessRows[r_GameManager.CurrentTurn].EnableGuessButtons();
        }
        private void updateColorFormGuessRow()
        {
            r_ColorForm.CurrentRow = r_GuessRows[r_GameManager.CurrentTurn];
        }
        private void guessButton_Click(object sender, EventArgs e)
        {
            ButtonGuess guessButtonClicked = sender as ButtonGuess;
            r_ColorForm.GetUserChoice(guessButtonClicked);
        }
        private void checkButton_Click(object sender, EventArgs e)
        {
            List<ButtonGuess> currentUIGuess = r_GuessRows[r_GameManager.CurrentTurn].GuessButtons;
            UserGuess userGuess = Parse.UIGuessToLogicGuess(currentUIGuess, r_ColorDictionary, r_GameManager);

            r_GuessRows[r_GameManager.CurrentTurn].DisableButtons();
            r_GameManager.UpdateGuess(userGuess);
            updateResultButtons();
            continueToNextTurn();
        }
        private void updateResultButtons()
        {
            int rowToUpdate = r_GameManager.CurrentTurn - 1;
            int bulls = r_GameManager.UserGuesses[rowToUpdate].Bulls;
            int cows = r_GameManager.UserGuesses[rowToUpdate].Cows;

            r_GuessRows[rowToUpdate].SetResultColors(bulls, cows);
        }
        private void continueToNextTurn()
        {

            if(r_GameManager.GameStatus == eGameStatus.InProgress)
            {
                updateColorFormGuessRow();
                r_ColorForm.ResetButtons();
                r_GuessRows[r_GameManager.CurrentTurn].EnableGuessButtons();
            }
            else
            {
                revealGoalSequence();
            }
        }
        private void revealGoalSequence()
        {
            for(int i = 0; i < r_GoalRow.Count; i++)
            {
                int indexInColorDictionary = (int)r_GameManager.GoalSequence[i];
                r_GoalRow[i].BackColor = r_ColorDictionary[indexInColorDictionary];
            }
        }
    }
}
