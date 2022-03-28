using Game;
using System;

namespace Wordle.Exceptions
{
    public class WinningWordException: Exception
    {
        public WinningWordException()
        {
        }

        public WinningWordException(Word word)
            : base(String.Format("Winning word must be included in word list"))
        {
        }

        public WinningWordException(string word, Exception inner)
            : base(word, inner)
        {
        }
    }
}
