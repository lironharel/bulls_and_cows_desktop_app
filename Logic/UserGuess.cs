using System.Collections.Generic;

namespace Logic
{
    public class UserGuess
    {
        private readonly List<eGuessOption> r_GuessSequence;
        private int m_Bulls;
        private int m_Cows;

        public List<eGuessOption> GuessSequence
        {
            get
            {
                return this.r_GuessSequence;
            }
        }
        public int Bulls
        {
            get
            {
                return this.m_Bulls;
            }
        }
        public int Cows
        {
            get
            {
                return this.m_Cows;
            }
        }
        public UserGuess(List<eGuessOption> i_GuessSequence, List<eGuessOption> i_GoalSequence)
        {
            this.r_GuessSequence = i_GuessSequence;
            this.updateBullsAndCows(i_GoalSequence);
        }
        private void updateBullsAndCows(List<eGuessOption> i_GoalSequence)
        {
            int bullsCount = 0;

            int cowsCount = 0;
            for (int i = 0; i < this.r_GuessSequence.Count; i++)
            {
                if(this.r_GuessSequence[i] == i_GoalSequence[i])
                {
                    bullsCount++;
                }
                else if(i_GoalSequence.Contains(this.r_GuessSequence[i]))
                {
                    cowsCount++;
                }
            }

            this.m_Bulls = bullsCount;
            this.m_Cows = cowsCount;
        }
    }
}
