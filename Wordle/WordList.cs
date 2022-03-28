using System.Collections.Generic;

namespace Game
{
    public class WordList
    {
        public List<Word> Words; 
        public WordList()
        {
            Words = new List<Word>();
        }

        public void AddWord(Word word)
        {
            Words.Add(word);
        }    
    }
}
