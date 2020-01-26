using System;
using System.Collections.Generic;

namespace Logic
{
    public class Generate
    {
        public static List<eGuessOption> GetRandomSequence(int i_SequenceLength)
        {
            List<eGuessOption> randomSequence = new List<eGuessOption>();
            Random randObj = new Random();

            while (randomSequence.Count != i_SequenceLength)
            {
                eGuessOption guessElement = (eGuessOption)randObj.Next(0, 8);

                if (!randomSequence.Contains(guessElement))
                {
                    randomSequence.Add(guessElement);
                }
            }

            return randomSequence;
        }
    }
}

