using NUnit.Framework;
using Wordle.Exceptions;
using Game;

namespace Wordle.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldBeValidLettersForValidWord()
        {
            var wordleWord = new Word("valid");
            var expected = new char[] { 'v', 'a', 'l', 'i', 'd' };
            Assert.AreEqual(wordleWord.Letters, expected);     
        }

        [Test]
        public void ShouldThrowExceptionForTooShortWord()
        {
            var wordleWord = "val";
      
            Assert.Throws<WordLengthException>(() => new Word(wordleWord));
        }

        [Test]
        public void ShouldThrowExceptionForTooLongWord()
        {
            var wordleWord = "validity";
            Assert.Throws<WordLengthException>(() => new Word(wordleWord));
        }

        [Test]
        public void ShouldThrowExceptionForInvalidChars()
        {
            var wordleWord = "val *";
            Assert.Throws<WordLetterException>(() => new Word(wordleWord));
        }

        [Test]
        public void ShouldThrowExceptionForEmptyString()
        {
            var wordleWord = "     ";
            Assert.Throws<WordLetterException>(() => new Word(wordleWord));
        }

        [Test]
        public void TwoWordsAreNotEqual()
        {
            var firstWord = new Word("valid");
            var secondWord = new Word("words");
            Assert.AreNotEqual(firstWord.Letters, secondWord.Letters);
        }

        [Test]
        public void TwoWordsAreEqual()
        {
            var firstWord = new Word("valid");
            var secondWord = new Word("valid");
            Assert.AreEqual(firstWord.Letters, secondWord.Letters);
        }
    }
}