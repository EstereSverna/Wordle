using System;

namespace Wordle.Exceptions
{
    public class WordLetterException: Exception
    {
        public WordLetterException()
        {
        }

        public WordLetterException(string word)
            : base(String.Format("Invalid word characters: {0}. It should contain only letters.", word))
        {
        }

        public WordLetterException(string word, Exception inner)
            : base(word, inner)
        {
        }
    }
}
