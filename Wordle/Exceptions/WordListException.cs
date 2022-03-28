using Game;
using System;

namespace Wordle.Exceptions
{
    public class WordListException: Exception
    {
        public WordListException()
        {
        }

        public WordListException(Word word)
            : base(String.Format("Word {0} is not included in list.", word))
        {
        }

        public WordListException(string word, Exception inner)
            : base(word, inner)
        {
        }
    }
}
