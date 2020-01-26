using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Properties
    {
        private const int k_MinGuessesAllowed = 4;
        private const int k_MaxGuessesAllowed = 10;

        public static int GetMinGuessesAllowed()
        {
            return k_MinGuessesAllowed;
        }
        public static int GetMaxGuessesAllowed()
        {
            return k_MaxGuessesAllowed;
        }
    }
}
