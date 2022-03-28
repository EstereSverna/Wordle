using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Wordle.Exceptions;

namespace Game
{
    public class Word
    {
        public char[] Letters { get; set; }
        public Word(string word)
        {
            try
            {
                ValidateWord(word);
                Letters = word.ToCharArray();
            }
            catch (WordLengthException ex)
            {
                throw ex;
            }
        }

        public void ValidateWord(string word)
        {
            if (word.Length != 5)
                throw new WordLengthException(word);
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            if (!regex.Match(word).Success)
            {
                throw new WordLetterException(word);
            }
        }

        public List<int> MatchedPositions(Word secondWord)
        {
            List<int> matched = new List<int>();
            for(int i = 0; i<5; i++)
            {
                if(Letters[i] == secondWord.Letters[i])
                    matched.Add(i);
            }

            return matched;
        }

        public List<int> IncorrectPositions(Word secondWord)
        {
            List<int> incorrectlyPositioned = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                if (Letters.Contains(secondWord.Letters[i]) && !MatchedPositions(secondWord).Contains(i))
                    incorrectlyPositioned.Add(i);
            }

            return incorrectlyPositioned;
        }
    }
}
