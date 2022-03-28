using System.Collections.Generic;
using System.Linq;
using Wordle.Exceptions;

namespace Game
{
    public class Wordle
    {
        public List<Word> gameWords;
        public List<Word> triedWords;
        public Word winningWord;

        public Wordle()
        {
            var wordList = new WordList();
            var triedWordList = new WordList();
            gameWords = wordList.Words;
            triedWords = triedWordList.Words;
        }
        public bool HasWinner()
        {
            if (triedWords.Any(a => a.Letters.SequenceEqual(winningWord.Letters)))
                return true;
            return false;
        }

        public List<Word> GetTriedWords()
        {
            return triedWords;
        }

        public void AddTry(Word tried)
        {
           if (!gameWords.Exists(a => a.Letters.SequenceEqual(tried.Letters)))
              throw new WordListException(tried);
           if (!gameWords.Exists(a => a.Letters.SequenceEqual(winningWord.Letters)))
              throw new WinningWordException(winningWord);
            triedWords.Add(tried);
        }

        public bool IsLost()
        {
            if (triedWords.Count >= 6 && !HasWinner())
                return true;
            return false;
        }
    }
}
