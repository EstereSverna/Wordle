using NUnit.Framework;
using System.Collections.Generic;
using Wordle.Exceptions;
using Game;

namespace Wordle.Test
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyGameHasNoWinner()
        {
            var game = new Game.Wordle();

            Assert.False(game.HasWinner());
        }

        [Test]
        public void EmptyGameHasNoTriedWords()
        {
            var game = new Game.Wordle();
            var expected = new List<Word>();

            Assert.AreEqual(expected, game.GetTriedWords());
        }

        [Test]
        public void TriedWordIsAddedToArray()
        {
            var game = new Game.Wordle();
            var tried = new Word("valid");
            game.gameWords.Add(tried);
            game.winningWord = new Word("valid");
            game.gameWords.Add(game.winningWord);

            var expected = new List<Word>();

            expected.Add(tried);
            game.AddTry(tried);

            CollectionAssert.AreEqual(expected, game.GetTriedWords());
        }

        [Test]
        public void TryWrongWordOnceAndDoNotLoseYet()
        {
            var game = new Game.Wordle();
            var tried = new Word("false");
            game.gameWords.Add(tried);
           
            game.winningWord = new Word("valid");
            game.gameWords.Add(game.winningWord);

            game.AddTry(tried);

            Assert.False(game.IsLost());
        }

        [Test]
        public void TryWrongWord6TimesAndLose()
        {
            var game = new Game.Wordle();
            var tried = new Word("false");
            game.gameWords.Add(tried);
            game.winningWord = new Word("valid");
            game.gameWords.Add(game.winningWord);

            for (int i = 0; i < 6; i++)
            {
                game.AddTry(tried);
            }

            Assert.True(game.IsLost());
        }

        [Test]
        public void TryWordNotIncludedInWordList()
        {
            var game = new Game.Wordle();
            game.gameWords.Add(new Word("valid"));
         
            Assert.Throws<WordListException>(() => game.AddTry(new Word("false")));
        }

        [Test]
        public void WinningGameWithRightWord()
        {
            var game = new Game.Wordle();
            var word = new Word("valid");
            game.gameWords.Add(word);
            game.winningWord = word;
            Assert.False(game.HasWinner());
            game.AddTry(word);
            Assert.True(game.HasWinner());
        }

        [Test]
        public void WinningWordIsIncludedInGame()
        {
            var game = new Game.Wordle();
            var word = new Word("false");
            game.gameWords.Add(word);
            game.winningWord = new Word("valid");
     
            Assert.Throws<WinningWordException>(() => game.AddTry(word));
        }

        [Test]
        public void TwoWordsWithoutMatchingLetters()
        {
            var firstWord = new Word("trees");
            var secondWord = new Word("valid");
            var expected = new List<char>();
            CollectionAssert.AreEqual(expected, firstWord.MatchedPositions(secondWord));
        }

        [Test]
        public void TwoWordsWithMatchingFirstLetter()
        {
            var firstWord = new Word("vroom");
            var secondWord = new Word("valid");
            var expected = new List<int>() {0};
            CollectionAssert.AreEqual(expected, firstWord.MatchedPositions(secondWord));
        }

        [Test]
        public void TwoWordsWithMatchingAllLetters()
        {
            var firstWord = new Word("valid");
            var secondWord = new Word("valid");
            var expected = new List<int>() { 0, 1, 2, 3, 4 };
            CollectionAssert.AreEqual(expected, firstWord.MatchedPositions(secondWord));
        }

        [Test]
        public void TwoWordsWithoutMatchingIncorrectPositions()
        {
            var firstWord = new Word("broom");
            var secondWord = new Word("valid");
            var expected = new List<int>() { };
            CollectionAssert.AreEqual(expected, firstWord.IncorrectPositions(secondWord));
        }

        [Test]
        public void TwoWordsWithIncorrectPositions()
        {
            var firstWord = new Word("april");
            var secondWord = new Word("valid");
            var expected = new List<int>() {1, 2};
            CollectionAssert.AreEqual(expected, firstWord.IncorrectPositions(secondWord));
        }
    }
}
