using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GameManager
    {
        private const int k_SequenceLength = 4;
        private int m_MaxNumberOfTurns;
        private int m_CurrentTurn;
        private List<eGuessOption> m_GoalSequence;
        private List<UserGuess> m_UserGuesses;
        private eGameStatus m_GameStatus;

        public eGameStatus GameStatus
        {
            get
            {
                return this.m_GameStatus;
            }
        }
        public List<eGuessOption> GoalSequence
        {
            get
            {
                return this.m_GoalSequence;
            }
        }
        public List<UserGuess> UserGuesses
        {
            get
            {
                return this.m_UserGuesses;
            }
        }
        public int CurrentTurn
        {
            get
            {
                return this.m_CurrentTurn;
            }
        }
        public int MaxNumberOfTurns
        {
            get
            {
                return this.m_MaxNumberOfTurns;
            }
        }

        public GameManager(int i_MaxNumberOfTurns)
        {
            this.m_UserGuesses = new List<UserGuess>();
            this.m_GoalSequence = Generate.GetRandomSequence(k_SequenceLength);
            this.m_CurrentTurn = 0;
            this.m_MaxNumberOfTurns = i_MaxNumberOfTurns;
            this.m_GameStatus = eGameStatus.InProgress;
        }
        public void UpdateGuess(UserGuess i_NextGuess)
        {
            this.UserGuesses.Add(i_NextGuess);
            this.m_CurrentTurn++;
            bool v_GuessIsCorrect = (i_NextGuess.Bulls == k_SequenceLength);

            if (v_GuessIsCorrect)
            {
                this.m_GameStatus = eGameStatus.Win;
            }
            else if(this.m_CurrentTurn == MaxNumberOfTurns)
            {
                this.m_GameStatus = eGameStatus.Lose;
            }
        }
    }
}
