using NUnit.Framework;
using Game;

namespace Wordle.Test
{
    public class WordListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyWordListShouldContainNoWords()
        {
            var wordList = new WordList();
      
            Assert.AreEqual(0, wordList.Words.Count);
        }

        [Test]
        public void ListShouldContainOneAddedWord()
        {
            var wordList = new WordList();
            var word = new Word("valid");
            wordList.Words.Add(word);
            Assert.AreEqual(1, wordList.Words.Count);
        }

        [Test]
        public void ListShouldNotContainNotAddedWord()
        {
            var wordList = new WordList();
            var word = new Word("valid");
   
            Assert.False(wordList.Words.Contains(word));
        }

        [Test]
        public void ListContainsAddedWord()
        {
            var wordList = new WordList();
            var word = new Word("valid");
            wordList.Words.Add(word);

            Assert.True(wordList.Words.Contains(word));
        }
    }
}
