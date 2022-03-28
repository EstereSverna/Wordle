using System;

namespace Wordle.Exceptions
{
    public class WordLengthException:Exception
    {
        public WordLengthException()
        {
        }

        public WordLengthException(string word)
            : base(String.Format("Invalid word length: {0}. It should be 5.", word.Length))
        {
        }

        public WordLengthException(string word, Exception inner)
            : base(word, inner)
        {
        }
    }
}

