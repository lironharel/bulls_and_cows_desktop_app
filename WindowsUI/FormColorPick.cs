using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsUI.FormGameComponents;

namespace WindowsUI
{
    class FormColorPick : Form
    {
        private const int k_Margin = 10;
        private const int k_ButtonSize = 50;
        private const int k_ButtonGap = 5;
        private readonly List<ButtonGuess> r_ColorButtons;
        public List<ButtonGuess> ColorButtons
        {
            get { return r_ColorButtons; }
        }
        private ButtonGuess m_GuessButtonToEdit;
        public ButtonGuess GuessButtonToEdit
        {
            get{return m_GuessButtonToEdit;}
            set{m_GuessButtonToEdit = value;}
        }
        private GuessRow m_CurrentRow;
        public GuessRow CurrentRow
        {
            get { return m_CurrentRow; }
            set { m_CurrentRow = value; }
        }

        public FormColorPick()
        {
            r_ColorButtons = new List<ButtonGuess>();
            initializeComponent();
        }
        private void initializeComponent()
        {
            this.Name = "FormColorPick";
            this.Text = "Pick a Color:";
            this.BackColor = SystemColors.Info;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            initButtons();
            initFormSize();
        }
        private void initFormSize()
        {
            const int k_FormHeight = k_Margin + (k_ButtonSize * 2) + k_ButtonGap + k_Margin;
            const int k_FormWidth = k_Margin + (k_ButtonSize * 4) + (k_ButtonGap * 3) + k_Margin;

            this.ClientSize = new Size(k_FormWidth, k_FormHeight);
        }
        private void initButtons()
        {
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    ButtonGuess button = new ButtonGuess(getButtonLocation(i, j), k_ButtonSize);

                    button.Enabled = true;
                    button.Click += colorButton_Click;
                    r_ColorButtons.Add(button);
                    this.Controls.Add(button);
                }
            }

            setColors();
        }
        private Point getButtonLocation(int i_RowNumber, int i_ColumnNumber)
        {
            Point buttonLocation = new Point(k_Margin
                                             + (k_ButtonSize + k_ButtonGap) * i_ColumnNumber,
                                             k_Margin
                                             + (k_ButtonSize + k_ButtonGap) * i_RowNumber);

            return buttonLocation;
        }
        private void setColors()
        {
            List<Color> colorDictionary = Properties.GetColorDictionary();

            for (int i = 0; i < colorDictionary.Count; i++)
            {
                r_ColorButtons[i].BackColor = colorDictionary[i];
            }
        }
        private void colorButton_Click(object sender, EventArgs e)
        {
            ButtonGuess colorButton = sender as ButtonGuess;

            if (m_GuessButtonToEdit.BackColor == SystemColors.Menu)
            {
                m_CurrentRow.DecrementRemainingSelections();
            }
            m_GuessButtonToEdit.BackColor = colorButton.BackColor;
            colorButton.Enabled = false;
            this.Close();
        }
        public void ResetButtons()
        {
            foreach(ButtonGuess colorButton in r_ColorButtons)
            {
                colorButton.Enabled = true;
            }
        }

        public void GetUserChoice(ButtonGuess i_GuessButtonClicked)
        {
            m_GuessButtonToEdit = i_GuessButtonClicked;
            this.ShowDialog();
        }
    }
}
