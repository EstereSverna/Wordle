using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Game;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            var game = new Game.Wordle();
            AddWordsToList("C:/Users/ester/Desktop/Wordle/ConsoleApp1/WordFiles/Dictionary.txt", game.gameWords);
            game.winningWord = game.gameWords[8];

            do 
            {
                Console.WriteLine("Write the CHOSEN word >");
                var input = Console.ReadLine();
                var word = new Word(input);
                game.AddTry(word);

                Console.WriteLine("Matched positions are >");
                game.winningWord.MatchedPositions(word).ForEach(i => Console.Write("{0}\t", i));
                Console.WriteLine("Incorrect positions are >");
                game.winningWord.IncorrectPositions(word).ForEach(i => Console.Write("{0}\t", i));
            } while (!game.IsLost() && !game.HasWinner());

            if (game.HasWinner())
                Console.WriteLine("Congratulations! You won!");
            else 
                Console.WriteLine("Unfortunately you lost. The CHOSEN word was " );
            foreach (char i in game.winningWord.Letters)
            {
                Console.Write(i);
            };
        }

        static void AddWordsToList(string path, List<Word> dictionary)
        {
            StreamReader reader = new StreamReader(path);
            string text = reader.ReadToEnd();

            char[] separator = { ',' };
            string[] singleWords = text.Split(separator);

            foreach (string newWord in singleWords)
            {
                dictionary.Add(new Word(newWord));
            }
            reader.Close();
        }
    }
}

