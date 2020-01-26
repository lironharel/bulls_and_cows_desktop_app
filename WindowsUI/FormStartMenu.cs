using System;
using System.Windows.Forms;

namespace WindowsUI
{
    partial class FormStartMenu : Form
    {
        private int m_NumberOfChances;
        private readonly int r_MinChances;
        private readonly int r_MaxChances;

        public FormStartMenu()
        {
            InitializeComponent();
            this.r_MinChances = Logic.Properties.GetMinGuessesAllowed();
            this.r_MaxChances = Logic.Properties.GetMaxGuessesAllowed();
            this.m_NumberOfChances = r_MinChances;
            buttonNumberOfChances.Text = string.Format("Number of chances: {0}", m_NumberOfChances);
        }

        private void buttonNumberOfChances_Click(object sender, EventArgs e)
        {
            if(m_NumberOfChances == r_MaxChances)
            {
                m_NumberOfChances = r_MinChances;
            }

            else
            {
                m_NumberOfChances++;
            }

            buttonNumberOfChances.Text = string.Format("Number of chances: {0}", m_NumberOfChances);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormGame(m_NumberOfChances).ShowDialog();
        }
    }
}
